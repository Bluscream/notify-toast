using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace ActionCenterListener
{

    public class NotificationPayload
    {
        public string? ToastTitle { get; set; }
        public string? ToastBody { get; set; }
        public List<string> Images { get; set; } = new();
        public string? RawXml { get; set; }
        public bool? IsSilent { get; set; }
        public string? ToastApp { get; set; }

        public static NotificationPayload? Parse(string? payloadXml)
        {
            if (string.IsNullOrWhiteSpace(payloadXml)) return null;
            var payload = new NotificationPayload { RawXml = payloadXml };
            try
            {
                var doc = XDocument.Parse(payloadXml);
                var toast = doc.Root;
                if (toast == null) return payload;

                // Try to parse <header id="..." title="..."/>
                var header = toast.Elements("header").FirstOrDefault();
                if (header != null)
                {
                    var idAttr = header.Attribute("id")?.Value;
                    if (!string.IsNullOrWhiteSpace(idAttr))
                        payload.ToastApp = idAttr;

                    var titleAttr = header.Attribute("title")?.Value;
                    if (!string.IsNullOrWhiteSpace(titleAttr))
                        payload.ToastTitle = titleAttr;
                }

                // Try to find text elements, but only set ToastTitle if not already set by header
                foreach (var text in doc.Descendants("text"))
                {
                    if (payload.ToastTitle == null)
                        payload.ToastTitle = text.Value;
                    else if (payload.ToastBody == null)
                        payload.ToastBody = text.Value;
                }
                foreach (var img in doc.Descendants("image"))
                {
                    var src = img.Attribute("src")?.Value;
                    if (!string.IsNullOrEmpty(src))
                        payload.Images.Add(src);
                }
                // Parse <audio silent="true"/> or <audio silent="false"/>
                var audio = doc.Descendants("audio").FirstOrDefault();
                if (audio != null)
                {
                    var silentAttr = audio.Attribute("silent")?.Value;
                    if (silentAttr != null)
                    {
                        if (string.Equals(silentAttr, "true", StringComparison.OrdinalIgnoreCase))
                            payload.IsSilent = true;
                        else if (string.Equals(silentAttr, "false", StringComparison.OrdinalIgnoreCase))
                            payload.IsSilent = false;
                    }
                }
            }
            catch { /* ignore parse errors */ }
            return payload;
        }
    }
}