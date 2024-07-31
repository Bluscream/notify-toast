﻿using notify_toast.Properties;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;

namespace notify_toast {
    internal static class Config {
        internal static string Time => ConfigurationManager.AppSettings["BannerOnScreenTime"];
        internal static string MaxNumberNotification => ConfigurationManager.AppSettings["MaxNumberNotification"];
        internal static string NotifyUsingPrimaryScreen => ConfigurationManager.AppSettings["NotifyUsingPrimaryScreen"];
        internal static ushort MaxImageSize => ushort.Parse(_MaxImageSize);
        internal static string _MaxImageSize => ConfigurationManager.AppSettings["MaxImageSize"];

        internal static string Image => ConfigurationManager.AppSettings["Image"];
        internal static string Position => ConfigurationManager.AppSettings["Position"];


        internal static void Setup() {
            if (Time is null) ConfigurationManager.AppSettings["BannerOnScreenTime"] = "10";
            if (MaxNumberNotification is null) ConfigurationManager.AppSettings["MaxNumberNotification"] = "1";
            if (NotifyUsingPrimaryScreen is null) ConfigurationManager.AppSettings["NotifyUsingPrimaryScreen"] = "true";
            if (_MaxImageSize is null) ConfigurationManager.AppSettings["MaxImageSize"] = "40";

            if (Position is null) ConfigurationManager.AppSettings["Position"] = "0";
            if (Image is null) ConfigurationManager.AppSettings["Image"] = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAALoAAACVCAYAAADv9OASAAAz8UlEQVR42u2" +
            "d63IbR5bnUQABXkAQvFOiKZqiKMo0zaZomqaN5mIwMMGrKIKSSErUjZRly9dpud3jme2e3tVER3dPb8T" +
            "MOHZuMbPbMY7Z/dTzxfsGegQ9gh/Bb1Cb/8pMViKRlZVVqAIpNxVxAhRAAqisX536n5MnTyZs2040w8i" +
            "/q8SqxJ4x+5bYc8G+Fl47JFYiNtas73dmP2yLE+wxYk8ZxHaDxi+EwzP4z+zEQSf/uhmMLyKAW2ffMfC" +
            "rZyfxzJoGOgMckuP7mAHXQX/m6c8sPtCZBz8JwL0kzpmXP7PoQGca/PkpAVzl5c+AP7PGQGfZk8BePN+" +
            "SsEeIjRGbSCfsuVTCnic2S/4/nqaG53tS9Hcj8vDPJDvL6JyBbgT516agJa2EPUSgnSTwLpL/F4gtMSs" +
            "yKwu2zKxCbMWitpSkFwIukGwqFu//gqU6n7ELoPuPFgaaAi4xZyA6B6808EszXkEH4hsTeFoIoKMEzDn" +
            "y8zyzhQSFXQaeQ1/yAX6VWZnYNLlw8qlYpc8Ldqw/uHSmBDKfy/g+Aqn43MC+lS6SsVMFOsuqvDABvI8" +
            "AOE1+niE2y8wL+MUAwKugLybpBYXPbYLm/4ZJtu6XAOZuBtJT5oGfn6KEgU5ilk4adF9PnifQjRHgJsn" +
            "PUwkKuwz8rAb4ggZ4Py+PnyGPmgA8t28ZRGOnxEO/LECb2PdsfA+jdCoNQw4dPk8gq+YS9p3+hH1vkMC" +
            "XpsCXCPw3ushzAwn7cIjaA2IH/fT3y8T7z5HfGbGo4UKZZneAIDqeA4/nAHyTT4xzUpoA9JhQQvEtu8v" +
            "YfwQWCfR+g/tU9yWG2xL2/eGE/dFYwv7w1YT9hDw+eiVh7/eSR/L8XQL0Vgfx2AToGWITxMaZLRDJUck" +
            "k7Ju99D3wuNZGnx9m+jtL4B1m8AfV8ZBQeRYITwnmPJ+MTd48izAoPPwBeemoPD2c7tVIQWe3RC3kgJt" +
            "DfkgAf38kYe/2EPgITD1WMCkBuIsE8u08Bf/oQi38Y9DjFpU8QXT8Kvm7NWbrzDZS1PDaUooGtwPkMZO" +
            "MLJC92gDUJwZTu0WdEWyFjMW1VnIOyJ33iDisD8md+imc2Qi1++fI6+S1BfI7PckT0fSlhkFnwYznrbG" +
            "dDMRDcqCfXEzYtwjYE+RAhyxquYh0MgZvOkW9PmAH9LBbfVQePTqfsB8TO+imtttJLpJWby+vAx62yQy" +
            "/t8jy+g2kM7/3gp2B/ZTdkpvuqTGu4y00bVuBtCTju0fG97CdwExk5udkbL8aTdi/mLTsv5hMOPb0ErX" +
            "PLlLHBnt0gTqjI/LzEXl+/xyF3utzkTQYYHfYEfZzM4EPrMuhyaHBPyKDUU5Sz93HAE828YThblEgn3+" +
            "TAH5EdP+fjbv2aIiCrwTeMgMedo2ckLUUlV44UQE9/vdcVzJ9/XUzdTXkGS5WnKMN8t2rBOj7BOgHgj0" +
            "k9gGB+2OMHwH283EK8dEFf9sfcJ0PnBG34RAAQ07mGrsrfO2n4QNJFkAOL/uAHOQqGbw8AzxjndztFjo" +
            "ewSs88YN+erI48J+MUi/vBbzOy28qoIcVUxQgQ+hfxC1HMPaYaS6R77UG6Ue+210C8D1m91VG4qZDAug" +
            "HRIK8P6oHmstHyErEVu1Wc5xYiAzadzrJqALd0+tgQKGRb/fQrErGampKT2vQ70sM+PfP1wJ/v9fNyjQ" +
            "ia0Tg8fM8ZmubqE9xu59poXHFVppKjjvtzMjPB8zuCsaBv47MGPm9/T4qOxwbrffSckLgpC1pRSQZFZW" +
            "InrcX5LvhyWF9TZYqRrdri+boATwCKdHDQ18CeHh4Dn2jsga21UKzOVEfC3TsHLEVfBZ5//12124r7I5" +
            "ggB3P4XsicF8jx3z/PPXe3JA8uEFim2V8/5TrRXFOk6c082IIvRJ2I2/u5MotCvqtHIUpY53OwWhh6Ug" +
            "+AYXMzBY50XtdbuC60+ETuIYAfrwB2OFEZsnfL5PP2STvdYt8t1tt1HaZ7QnmBTxew3fCXRfzEtfIcT4" +
            "i8uQxyZbcJt76Ojl3BfL6SJJKTsi+dmb87vwDAf47WbMbeXNIliU2g7mTpTOcpznnihM0bLmzr3zGtSD" +
            "MzE77zOCKpQvihJVOx5vC3sdSmrgz7mSo3WyttVuttcDf8gAez+G7YJ4BEG910mTBehuLJ1jCIC9YznJ" +
            "Bz0rAt0vAt1inE3gDyfzMC3RlLQuCrqIAyl6e6vPTCjg/ORlm/ETyk8tPNs8WicZTpMOSwTuOSjbFLo4" +
            "Cy+PD+2+m9DOzuBB4wFhN00wINw78jYw/8Pg9SCY4nT0ix47IvMOHJFtyu5/Cje88IB1bj1UPfF4BfPY" +
            "lAt5HVXxfBzrL7Sr/APqzJIE+ap1uwNsVgOcUJ7lHANwP7jHJxhU2xe4gJYvm4mfSNDUJSbLF9DyCQoB" +
            "6h0B6RIL690lw+AnRy5+NUPv8ArWPSV76wwHX3icQ3ybS4y75/cPzdC4BdpNIsXVyIUyx7zwsXLBDCuC" +
            "9oNd5+cwpBt4nH1+SQf/a6/ZQTrigLzHQh63TAziHXAW4+LMMuOzRByTA/aCeYIa72ybxsjdy9BGzwrA" +
            "Z5unh5feIVn5AgPyQ5Kt/Qjzvl5ep/fmkYOT/X03W2k8n6KTYrS76nvgs0fh3GFVcqKKJ4JtC7wf8adL" +
            "wQyl/+aINQjFJwrXpdrsL+oh1ugDPKG6/QQBXSZZRBeQTCWoibFPMUMB2rZ0WsYl2yCazAO2XEy7kov2" +
            "M2Bfkd54QCfKwn067Y6JnWoglVIbvMirZiCH0Aw0Af9qC1lHv1WjfCtLcmbWrnSbOpu1t4kk22ynkyFJ" +
            "8ful0gK4CvN0AcA41B3tEkiccatGLc7DHEZAzkMYkm0ioS5NlWyDvt0kkxnViOyhpIGNbbaOpwwWPvxF" +
            "tOlEL/oTiu4wGBF8FfSPAnxQT096gPxdBr4ovvjE2ZD/4kWU/ukL0YA9NtSEHDdAxsXJSoIs63EuqyF5" +
            "7QKO7VbKESxGVx55SwKaCbzKhf48p6WKYDWBTwoU3LlyAXmYKvc7L+wF/GvR7IWkG+jOnUKu93d58d8r" +
            "e/fG4vU+g/pCA/oAEPre7XNAxCbPf3VzQ/XS4KoOikiFeulsH97RkMwaAToY01efJF5GXmYAfFHpT4E+" +
            "Dfp82lC51BVwPiJb8iARDHwzTehEERHe6mw+6lw7PeWhuP8B13lsFtx/Yc4Lx/PxcALC5TTZgYcCPAvi" +
            "cBvhMk727Zn3BMxH0mqKjS4Od9hHx5p8R0D8nnvwnlyjomF3koBeSzYW8XZEL71EElCaAm8KtA3vewxY" +
            "Srt6eismCgh8EehPgexTAZzWS5oQD1aon6CtTXXaR6PAPRmkNMkDf73JTjLe7af1Fs6SKTqbIgI+EBNz" +
            "Lc+vAXvCwRWHmNWoLA78p9CbAD/gAL4OfaYKUqZAs1XibwYSRDPqfTHY5jzt5t9h+heXTMUOKQikEpM2" +
            "SKl5ePErATeBWAe1lBUXWRL478O+gunP4ZV38LoAg0EcBfF4CX5Q1cUqZHgL40RuWvfKq5V8CoPLoeMR" +
            "UMkDfzbm5dICOEtiDHnoQzZAqQWSKDvCgcJuAXRBsSbJFjfzhME8EzLqoLoSw4MvQBwFepd9V8OdiljI" +
            "rr3fZR2+12NODyte7taDvXO1zHjF1fbODVvctC6B/QKarH52jBxQH5DqpYuLFowTcC+wlH+PdC3gRmdj" +
            "qA4VcYoZmNiLzAj8o8OMBgR+Q/u8FezYG2HdmuwnoafvScK/q9W+0oO/ODzgLnwH6ilUPOuq7PxmjAxK" +
            "VHveTKiZeXMyi+OWro4K76GMlyXgtP7/ApqTMjcqaBb0p8CMecxMqaaOTMlHo9t35QftovsVu9y6kO9S" +
            "CjmBUBzpsyYpPj4f14lM+pbemgAcBW4a57GHXUHFIZkPXM+7nz2oyOCoLcxF4zayaAu8laYaleYlRq/Y" +
            "ikL17HLr9JuHw6HXjdbu1efTdwkV7rY+Wm65KoJcE0DGdHVanm+rxoF48KOAmnlsHdtnQMIbrKbpg+3o" +
            "H/ZwF9t1UmRuvLM+ikNVRwR8UetVrUwbA81KICeFcjAnnyETKRKHbb5KqzqNJ/4XTNTOj3LYWRu1rgy7" +
            "o8Ooq0MOWAphArpIqJl58RtPzcT6A9/aCWwfzssawagiPqG250enKl1lNmlK0kvR+ZSkGUIGvA54ftzg" +
            "O4kU2q/DwspwZF35nXKoTahbsWOOKta7tBnXpdSuLVq+OHK+CkUGHfcLaIjwcpFDFCflISC8uAn6PpEP" +
            "/tpiy/7DXZf+/ez2O4ee/I889HPAG3A9uHdgVwQA570SAx70clTALhqDzO4LXZ5U9gFdBP6e4qL2An5E" +
            "kDffkw4JHn5JKhmXvPuKj2xuFHaAfoJFS1n/iqK69BQe9XQC9IpxgvsL+yQU6MMkIIO9TFGGppEpQL/7" +
            "sLesYbi/75dZr9mzeH24TqEXD2N3AUresuyYV/0ftUJXIl2W2kFuXjy9p3l8Ff1ED/Tx7TbyY/YCflCo" +
            "3RyXvrtL6OikTNey8Qxg6FqB7wXSXtu+L05Xr+MnFK+dc6K36gBSLjAH6Z+O001OP1Vj60FSPB/HiC4a" +
            "Qc/sfB3P2m6N9RnCrgOMgc4MX3yee+1YHrfjEc1hADcjvdFGvvspah4i5eBG0ouJ9RfMDn0vNouKiLfk" +
            "AP8fGV9TlQ231cmZSCnBNYBelTJTpR1wslU5NRy+mX45bo/Xm2l3oFZmX1ZSr03EL9ltWFwbymppwBeQ" +
            "zPpDfJ3LFFHJu/3b3sv2nb4w5jYD84PaCDwunUWcOmKutbkcB/Hynq9ZQOySDXhC8bl2zJaFFtgn4Kon" +
            "jB3xBCk5FTT7cps7OiAGuSsr46fYoYde0xHvBQVd2k8JK9RVF5oXLl4NeenCNyBUTyGWp4gU4DzShyYO" +
            "C7mj3e+fszXfesJdazeAWAXQ8NvHUe510+RygB+D4vwN3rtY2U/WzqwXuTCxziwJ6XsckB7Hi4o5pj5T" +
            "ktHBhyL8TBvZGNPt0RvM6A/2ZVxMdVYoRVYwAHY0+FyKGPKxUEbMpYSAX7fG1d+1CVg+2aOiaBZghVbb" +
            "JYO+Sx4Mub9vvpOO5pND1kDp11gD4psAvCqBPCfp8XCFRZNhnJdj9pExcsI+n/EGveu0ip0ox4gQhGIV" +
            "OX0jU59ObBfmCYm8ktF1rFHTYX+2/Y8/0t/iChZ4qgNfx3Dk94NzQ7qIsNFhaS+otLPym0BfZeM5ISwM" +
            "XpHGf8QB+5hTB7iddxjzLIBP1KUYMDPLBAH0jU98qmk/rNwq50wm21R1InRfn+fCoQOdB6tsXB+oAKpP" +
            "vVCDlyrMDLXb1lbR960re3rncZQQ5bCNV21lhxfKH3Rf+BoBfFKTKLBtLUb8v+MA+JaUyvXR7WNgjAP2" +
            "5WPSi7NXtVQqAE/Txq7RFndj+QlW7EtaTIzNxs4tmd0wg57nwqEDnQeryzEV7pYVlULA5WEvaOda3xvr" +
            "th70JY8BFjy7n74OCrgXfEPoKA7rAxntBkV4Vgefyxgv2+Qhgl1OPmWhg/1YEXRmQTqa9QUe5LiaOOOh" +
            "yhiWnaRTkBzkGCYAD9Bs5820cYX8fMhj1C1KXiScvscmJc/099s3zKafL1u3OWpDv+hh+pyJlPFYtt8+" +
            "jylRwv0nuKFcGc/YSmoW2BoNeXGPAU5tlD/1eklKROuDnpaA2KtgblDDPRNA9A1Iv0NFeDV59wgDygYC" +
            "Q84Fastz6Dp0XF/c4OhqM1qtz2BGkAnTefm4vS7tu4ef9rD/g3JCdgcRaFr57JaEHXWX8zuKk1nqTek8" +
            "vQV4UYgT++TgO5PpRgGYC/IIC9pkGYR+IB/aqvO25siGmKsXIJxecGVKrHvJcBJDPGUoV1XaNf/NuMnL" +
            "YYT+7uWi/NdjigAYw0B+R/yzCfk9jCFp32mmhlzgbK3bsFc0LdHyPqaEu+52+pJm0sVypUhAgL7M4AQE" +
            "1ug3f7qoNWHWwFxSwz0UIey4a2Lvl7f2Uv+iVeVlitSToUCUHn6raFTlPHgfkYjbhdzHB/qs7b9vvXeo" +
            "9hpoDid6K97r87U4n9ejX0rXVkHJ7ai+DXLqbN5M5fGa2rFgBtSDIJtg2y/tfz3jPtprAPi0UiJnALuf" +
            "ZVSW+uuB0Wr+G+YWqP7pR5kUEHcHoXrd/8ClP64eBXLfLdNljNvOrqUQssCNIrcyM2XcGaiHcbQ8AekZ" +
            "amGEIOj7j/UFvr7/GvPeyR139Iu8e5jEDK2dnln28u7h0UEwHB4V91AN2PwmDXQzHsz5luhLoL3SZFzn" +
            "FiANEXfrReX3wKVchTljRQj5PLrZSSy3gKKB62Ee/98cjCfsPd/pi0e3Xfzxrr2UEb5v2B/0u0+gwEfR" +
            "Kwgx09Gt89qbl/IwZWd5KGoAvK6b2i1Kx1hx7rJmg8snOVAxgX5BgnzeEfUJT9Wii149GE/a1EX3LCxn" +
            "050FTjEgBYhtG0wyLCvIZQ8hVUqVALrSR3i57uq/Fe48iYvdIhuj/3OqNLUhdzlII0TnXRL5w0JcTweX" +
            "LV69RA9zo0ossDhZ1QPcD9pIAoDjjuSicPzl375WhCQJ7UahnF726CDvakA/n2nxhDxKcHpH5nO1X1aB" +
            "7be0SGHQMHkCfTZkHn6oZzzCQc7mySOCa67a8d59jngv5699f74otSF0ZbTWCHIaF5wB91aoFxkS+wKP" +
            "/JZFk9/MU8Bsdrm23uaCLkPNcvbx1jV+GplHY5yTYUY8y2pWyJ9rrZ1BNg1NRr/cl6Sqj8S6flnSNgl5" +
            "goJdb1LrcJMMy57FkzDTolIuuVjXbLEJa/G4pE1uQuvn6kBHoqFOvMg8sX7iqbWNE0B8QwH9BGsGi3Lc" +
            "G8tZa6cJnKwsJV7uXE/75eRMp4xekirDLSwTnAmZidHp9C7tX9xgsjpZA/9p00qgkgb7ZodflJwJ5shZ" +
            "y0X61mIk3SO03C0gBrlxNiO++mfI2AIqCui/IwuAjssLm8Qj9m5m8dezNC8LY8otHLCc2gj0ZDeyzQnx" +
            "gCruJXsdii6VWbcZlzAv0Z16ge6UYUckI0LED2kAAXT4rrYLXpRBVkOv0uA5y8QSjOX+cQeoBycjc7/I" +
            "2BMzXM+oFHqtJNeTihYFAFFu9oH/95Z4OZwJJli0FAXRZGvkBH1bKyNmYGfZdZNhNg1OVhMGmZBNJ7aZ" +
            "dL3TbLxqDXpZAx/Z+Qwa6XJVhmehKRg75mg/kPOh7TNJ0/3knniD1g62CfXM448B447WeOtAdr96qX6Y" +
            "ngrkm5MRlA+g4V9yr8+xKUdhMTBXsGnv3CGBfkGDXZWJ0EoZvIwmvrtmK8WlkoBcF0JFPDiNZhrvb7WQ" +
            "y2VTIxRP982nLfjZn2b/fzsciZT7fede++vqkvfLOrNKrA3aeFgxjIuxTvS0O6GVBn/MOAvzcmcy+xgF" +
            "7QfLqCyElDP4Pp9pj+bZbuaoD/VvVH822qNePiqAfDJpLFg75ua4sW77XqYW87KHJTSBf10AO+2iYTsB" +
            "gtvF3P44vSF24Mu4pYbBXKJ/gacTE8ZoXFliL46bL5hhJGQ3sfnn2Jcmr+8GukjDw5Asp6tk1bS6+89s" +
            "5Wpl1KaT0oH/KQDeVLPPs4jkuHCO3XTn4bAbkKvvlm+lYg1Qv2JH6lDMsqrrzFYMLoiis+uftMkpMvvg" +
            "dfxywy4uwFwPodVnCbLS5EkYjW76OB3SSsL87GEyyTHfQ6ru5jCtZij6SRQX5Jlvh4ydVMHt5dTBrD5P" +
            "y2sHevPMon2QO2k8vxROk/se9URqk9iskTAetldFlW2CrBjKHQ7QkjeFmyuxi95MyQWFX1cYseuh1Pwm" +
            "DDeSGWf7cZH/RQKAveYBeEkDfzplLFnFSyFSXH7eSSNFtCrdZeez9blr2aqLHLw/21ByX11bnsEOSm/3" +
            "D7XiC1Idrb5MgNW3fJ99bNMB+Pd0Y6HxF0GrSHUNVyvKkYJf7yASVMPeGKOia7Vy+lyEPDLoqxSiCbiJ" +
            "Z5kNALoKO7WY+uUBBR7nrAwLkzTZ/yDekCjd49Q0f74kakm92uuMJUqvv2tfHOupgh+210a3Sq2wrdZQ" +
            "C47nbHbQUGMe+nvSGXGxjVxa8uW4Syg/2VQPYgwSnMuymEga7ZYPHrHfF4jeRg15mW72IoPtJFt2kUKA" +
            "MS5J6coCOW/6agR7PZmkK7uLIeXulTQ85PCuCxHvkM/6+1BpbkLo20a2EXbT9sTZ75/U++nMH3acUJsK" +
            "+JLWyKxhOQJnAzjtBrEcAu59e95MwAH2tVavPDxsDPVnfog4TFXcY6NWctzfXSZYwunw1QPpQtOUOqtP" +
            "X0nrAbxMdeJCl3nS/nWroX78T70yqF+S7F9vs6z96xb49mqkDHYaxKSh6NhYEr+6n+5FxutXK3jtDHcc" +
            "x5El3oslUxsQlYTjoW136RRaRgr6sAF325o1KFhlyfssOA7lOj2+yRRPw4KgjeSzNaO4x7//lpXhq22m" +
            "Q+iP7oK8e9OrMebs6PeB6dwl0jIsMuZg/3/AB/KCT2k6mfqz4JBN/n/UmwC5KGJVXB+gb3WazocFBF4r" +
            "5/UAP4811kkUcPDT+wcqazVQt5GXyPabOddnFnnCQ4yRDogDq9/so7CLoVeEOcNjd/CC1RsYAdLbNOoq" +
            "4ViypOlCY9l9Peh8zYgAcGzy5SsqsC+W+q5Z/gOpVG2MiYYJ4dYC+2uu/r2ikoGNf+/t9FPQbObejUyM" +
            "BqE6XwwPdbHNB5wN+aaDHsdVMMMjhxeGtOdAPuuohv5ut/ztkR36/FU+5L8oGtl7tsO+RixrmCXorrZM" +
            "BXAtCA6JCws1O6SDHhV1NexeNLWtq5LWw++j1sIEpB/3+oLZrbiky0OUWdY+GaCOj69ngAWgjuryacQc" +
            "bnrzUFQxyaHEAK8qTu50C5AwsvspfBcvX73XEFqRWXjvv6PM75+n34NCLoMNQ2FUU1n/6ZZK22XFva+K" +
            "UFct/1VMcEsYkMN0dCJZWbAh0nnnB4t6PLlCPXkmZe/OgkkWGnE+smOhyr5PNpQqHfCdTD/mNjH8g96u" +
            "34wlS/+fdN+x3Z1+z9y+ka7w7gmSsYtpndp2VUK8m/b+r06KjTT0xhb2Vpon8E1toZDva7f7uLqfbQCM" +
            "59jASxsur93mnFZ8HAV3Zrati1R4ABx3SBR5dBXqc3tw0+PSSK7In5wBApiBXjaDUb+JGtJ+Ox7cAe6f" +
            "whn2nL3EMuyxptg2/5xZbW+o1+/rmUNaB/Py58yQNS2uQ8P+poVzgCaU4vbomf/4sCOjKN1lP1oNeYaA" +
            "/GWHBaGfj3rwZkEOHP+qlWhzA32DpNMBzi6QSy93mgIv2MB9fkLr/p3NOkCrDDqumzSDHscq/Kwerzvj" +
            "nLHuP5O1X+yyjXHsUsJt6dYCuyZ+XGgadH5AckCLqf3yego5VLmG9uWcAqkklBoEcXg8eGyf7Y/J9Pxi" +
            "kYHKvzj3ke69kSJlAr72StQKDDphwAf17NR9bkFodqYddzpooM0qd1JuLz/PxFP+vSkfeJHeTGdIkqZT" +
            "zh10nYYIEpjqvHjR/HhnokC5/Pp2wPxw9nd4ckPPbe5Vpc67J8cghh2xZJo/LnVSvBgF8t80F74gExv+" +
            "4ko3Fs8/NvG5vXOyogx2TWrLUwvFh4gvHhkcZclHT8yyLagZ1nczcTp3vdybaTtqrj7eYl+XGAvovSY+" +
            "RJ68G8+brwtSySQDaiGQRMy0qTQv5cqstuAcXAZctjrIBZGPa29vtvUHvzwXYmAt43O8Wiom6fE1T7qv" +
            "Ku1+9MOSAfuVcT2QSJqxX14D+PBbQVwXQkXX5bwR0p+WFAnQvb46/vZN3Jz1MQQ8LeZS2JwC+c6XbLr1" +
            "91d5881IddP/19UTkXh3n483xYU/QP0S6d4Q+ypCvCxM7qqIw1RhCxi0Rvb6WMdfrUXr1pZMGfcVyNTo" +
            "HXTUL6qXN8bdoaAnbZ3v6hPHmuDNMD+bsQn8ydsB5ZywZrl3Sz+Vub+1zPHuDcoIog9TV4qLj1b1AfzJ" +
            "E45C9tvrAk0N+XPsjgb6WNB+HZnn1suV69Ymmgp6sBR0e/a/fqgddNQsqanNsUYjmO2hqidXw60lv0CE" +
            "rHGun0kMc3LdJj3DMiiKIrHTEC7nT91AhVyAVENw6/89ST4rfu8nuVr94w4oM9Op7Bbo9uEcWBnpdTiE" +
            "eO6ikK09UoOty8b8kfWT+gnQHe9QXv1cXZ0uXowYdi0lVb9JieYOOL/rpWML+zTtJB3RdEKrLm/tJFky" +
            "QoPUa7LoEOrIByAHDo69l4oVc5c25F/3sFTIWwzRtudvmav6fXY5WviAgxXm5dr7FuaBgziQSy5HLdz6" +
            "5/Yd4TDLofqUDcXh1vwXVIuiTLcGLuVSgl1RvMiAdhByQ/oRU9P33ectZN2oShIbNtPCsQpTavJqpz0j" +
            "oTih+tw50Atl9watzyJH2+5t3kpFXOfLzUu1xF3WvJ/23h1RlVFQrlBoFPaxX95Ivy5YblM5qVv3HDvp" +
            "nF9Wgh0ophsi0NOKpAeVhXg17XatmSbKgihKQIy3JHznk6Jb7+8326Ps77lLZggUkYvbEz/i2MWKW6UG" +
            "XekvGMHe6MF7dNCitWLXZl1hB39SAfivLQB83C0KD1LScVKalZnVNu1WTZeFeXAT8LpMOgPxD0iLu/+7" +
            "kYqlZP3/+vHNOLvVlj8evkjAAPVk7r4CLG3atxSzzEqdX9wtKZdAzyQZnRoOCLgakzwTQQ8uWJntzvxP" +
            "It2056FJDLhoCQECO7gH/uZ+PZbII2RZnz/u2NicTYbptO+/lUlOHTu44D3toW7diMjzocXl1EfT1ltq" +
            "ceq5F3wc9VtD/6qplf/RqcNly2rw5PFyVrRVFgKfS4/c8IEdGIq7CLh6AoshqUbF9uw50MZ1Yk24kx4n" +
            "3WiDfvZDRL6IOAjqcA5IG9/KNBaWcnY107UxpX6NFXYFAl1KMfzlDu7qaZFuCBqFBIUdR1sUh2ruFWzm" +
            "vhxvT5fvt3rONXpBzufJ3/yUVC+TY0JfLlVw2ay+l60ua67ZYV+xs7TVuy4ruxOJEEWRbENiR5p1+ZcB" +
            "ev9ztSKQo5IsM+nDA1f8q0J8q91dP60GvkhP9JfFmd3pOXraUPdYSXjnXW59xSdPtE6tTvfatsdZAkPP" +
            "JoAMiAf51tS0WyLFF+3FrDlITXrKk5qPCuAXtRnY8Xh4lABhHzEuY1vzw931zqNWxjWx08mUjXVsSMJF" +
            "usB7dq8HoTLp+LeGaBDpy6FttzZMtXgOOqerefL7uGODV5VX+APgm2db8+swr9taMO6WO1/Yl4/lqvMY" +
            "zK5hi//dr8awwev/6ktCuL1cHpLxjxXpI2OW2f0Fq8INq9bDyZTNdWxKg24EudtDRlN5UtsQJOgxQO71" +
            "bmHwB+Fg5I2Yd+NK0e90U9t1zSScfvSk17OEnpCJ5UcwO/mEv3qATNtWTUjZbXYugz6QIOgesesKgq+S" +
            "LDPpCyFJdY9A3NaAf9JqnFU1lS9gAFIA7e08yuKHPl4RFBPBax7nwrLubmyonzQe+JNRefHqhOUEndnL" +
            "gF5k4jpWE96a56wGBly8gZGS2TwB23eQRdieX90YNk2JsCPRVBvpePnp9HhZ0AA7YK1m32xY3BJ486OS" +
            "r+1WZioqwPcqScAf6zdvJpgSd5XS9x1sWWk84z6XUm24FgV0GHcG17NWraVe6+Xn8qEBf1oC+qE8xPm0" +
            "K6Cepz3Uzn0fdtD6be/KDbO2ePqKVhNtkQZAK/1hOx7bin4/1ud7uYw2uMtFR8IthrYGGTvKdAjBfazl" +
            "dOl0EnZ8XTeblaxPQvw4EelIPehh9HuUk0V/PWTbKVd/vpQVXj3pcbb6RUm8+tSQ10oGhnuR/r7fHH3T" +
            "25X1rVUw3ItNtm+4FOg/So5pR9ps8MtXpay31NerjITIvvq0uiin3Kq9rUM88yn53yPx5jN4cEzgHxEN" +
            "9NZmwv7goLJTIqCEXe3Zz2LGP5x924wk6ebmt40x6U761Ko3ALjYjKidqQedyCCnTaiba8okodDp+RwZ" +
            "9qiV4bxdf0JeT9aDLASkH/aT1uWjQ4AD8J6O0HQVfO6kaWLkx/ULMQSfPrCDonM3W3vE22AqmqGDH74i" +
            "NXMWdL7gOrrIJs6jrhKLQ6SLoSw1kXpoOup8+nyIrzt2eIl0NTfk7/VuEdm6bkmQpS16cW1xBJ5oS8aA" +
            "zn8vZ8xkXQj5Gu6xbAb4fPD2C0+VEONh5+W5R2oadg849PUqKb2ROJ+iYn1GBHjTzEgh0rxTjbQXoYQL" +
            "RSlv95wOItXQ40DngznK3ttpBVUGO5/92KRV70DlMZh3FoF2GnRuqFHkmppTWwK7x6svSZ6hAR31KIzn" +
            "0OAPS621uelesZsy3BKt58QW94gP6KgNdl3ExDUTLWfWXB+ybDYAOE5fqqSBHMBZHDbkcdA73dtUBLpo" +
            "I+lRfh7vSi+XWVbCvs+WGiElk0MsJb+nCs0xYmbTVEk+Zc6MB6a1OWoDGvfr9ft/MyzdNA90o46K4zQJ" +
            "oL+2F/YfCgn6z1f3cZQXkWKrXjKDzSndKC3lRSPXBii2Jml6I+Fml2XlJA3S2DPqKVe/RxWV2JXZe/AJ" +
            "RzDBXsvHLFxn0gx46O8pBxyx8mJqXxkBPmoNuEogm9EGGs2OFrmoRDYjEQiSnr0nW9eYqyD8dbV7Q6Qe" +
            "5SsIUWql0QR26mJ0RQd9hM5oqCVNRvL/c6L/kU+eCMeXHoSv00i13DKPT15BU6KlNMX4yFq7mxQh03NZ" +
            "0KcZmgS4WZ9WUm+ZotR0MC6WPMy+d1FNxyOUUInaMjjvoREdaMeg0sRKrO0H2hQPs9NFJu156xVCrVzQ" +
            "aXWz2z+uA8Ph0rLZdxqoQO8Gzq2AHH3dZz/WoQN8g73k7Xwv65ySDVrR8My9jkYEuypeoQOebaYmG/UD" +
            "R0RVT+3h9tV3dCZaD/g5pcXzcaKjDDcgKAuirTQo687ms85kqmD8j6cvfkuzOP5UzSvvn5Vb7f621299" +
            "sZe3fb3TY/0bKgfF/2L+utNn//F5rvS2r7Z/ey9TZv5Dn/0V4DS05npA1BR8MJOxfv5U8XmHFx1KUUGK" +
            "RnFgqANAPOqMDHU1sATp2PhRB32yloGs661ZjAR3pxUZz6Lj9Vsgs5msT4/bEpXF79c1Je3/IbXPhbEP" +
            "Srx5kLBIo9ln2cq5WYsGbVwTIC+wWHddM56c33KDzXHenEnB0CviP7c5YPj8K+4edC/bPi73O2KFsgrf" +
            "tgAPhsKvOgXMHzVG7no4GdPT92e+qBf3JBToTH3S1UWDQVQEpPrhR0B8P0ZlIbKfI4Rbtdofrvf2CoTU" +
            "WV+BzlgTInaBzryuWoPNg3YX8UneHpxc/rYDL8cXy7GXSTzPpdAsQPTuqQb10OvLxd3Pqjb+Cgo7nnS5" +
            "uXdSDc9AfkIvv4aDvaqNvTxR0XQ79o+GE/Yy0tvvqCinC6qOrdzjkWMjLP9+vfzl/v2tSMdBno/HtKCc" +
            "GndNdlhJyeMg4atjjMsQZFy+84sCOdtimmS5n09/2xkG/3uqCvpJ0pTF+/2O2PjlIQ6PGQU9GAzofBBR" +
            "RfXmZfoYIuskg8++z1VI7mxZX0AnPx4NOZEV0QedvY5ptjdOQGvVKAPhVjarkS5DGRpAt98kFdjNLJ4n" +
            "E9obgDY2NZpLmmZdTBzreGx79TicdrFusljwI5HwnZTz328Vk7EEn0n9i0LmQoiaC/jJ5c3nd6jsDqcC" +
            "wb6frMzAmoOPcbWEdQc4FXV7rsMhgn9dnXq6GAl0XkN7KRQs6DFLGtMaF/z3kgQh5s4LOkuS9sc4TxmH" +
            "HhM7LBjmXLzjGCwN9oWZHqxLsJqCDFTSe5aBvt7nNa0XQuU437fMSCeibmehBNy3mwt9uM89fEQYjDsj" +
            "loPNyT8dxHppDDvkyTOCHjfZkjzMtLzPo/T35wEVfGwLsvAOyH+g4fzc6akHHpJEKdHj01RbzzIsv6Cu" +
            "petA3TxHoaCW92+FmWGCfvZqIPeicIUGnWBHIQS9YuAAy9pV80vm5yNpIvMyg9+Y7nWNQbSFjUgawk6n" +
            "t9FsDuuXOuVTbaa98DvrRAGWH72Ekgo6qRmR/TDMv0YDe2nzQt1lfFqS+8PdLMXpzVdBZkkpf/WY7T3P" +
            "u3K+pKUDn/dP5bG0Q0J1sTNaFnXtvXm+O/WqhxQG5DHrRA3R4c4BumnkxAh1XcRSgR7Xowtloi0EuF+b" +
            "D4gw6lxL1kJuA/vPXrZcOdN6VYIRINPHcXk/ry3pFNnjJgnMnuNJrr05029jaHUswb3ZQ43JFBv39c5Q" +
            "jDvqiVJPubAJsmHl56UA/7rCVoe9RkiDH63EEnSivLXlAbgI7ju1l8upip7DZtNvOpCgE+9VWyoYDfoY" +
            "anA/vDy+fv62pPvvH8z9yMmqOYdWXYCLoe1y6WLWg8zIOpBdv5OhrJjUvRqBvp9UBqQh6M9aL4rMBuVj" +
            "otKSwKIJOsYb8Sm/H8bKzsKDz7MvLkGYU72KjrH6ee9Gi4MBwHnZZjITt2vkWPPtZCvJ+h7RjCAFzdzh" +
            "lBDomiw4H6Odw0BcE0DcyNCDFa+0p/9VGDYHOYW8G6LAbbPsSHqkveYDeyDS/2C3LWc7Xk7LlpjqNwI5" +
            "j/E0xdyoBx7HLd7FlRa8VuT2euNGXc8dtp4bZba7NOSvw/vxC0IF+D7t791Go/UDPG/R5EUH/TvXLKJH" +
            "UgX6zvbkenZeilhLeoIfdUkUMOpPJpD2ddhdLFyICnds2Gbcnf3LZCfhOg4lpU1zguIuptn7RGc4Lb77" +
            "KW0jj5wNW/yJmXZwAVQP6w35aiz7vATogfzBAXxsySDH67kjH86BemZedtnrQiyFXGOmyLjut7t9VNJA" +
            "7u3C0JULdrsUa8jmrtr/LgnDrjgp2Zxa1ha48GiUBn87GerlllYb1pVcGOutsajBnm9g0WYgOK7D2fRj" +
            "3SgDIxfPNz7Oj49Mu7PtZYRfvjNqj77GdCrFR806Hu2s035Gcg47uzRz0UYPd6k4OdJ/mRYAVdS7Q5Pd" +
            "76C2P10IUNZBzj/95gFw6T6M5izvyWU/I+R5NpYhhN1mI4Wfco65FvOP2ajIY6Kq7ntP7h0kVxxSyRQT" +
            "9bjeVLWgZLYI+J4COfvxcuowbpBiNQffKvBywMsoougCIJwSfiQF50EsPnJfdqiRLMeHu7iDak/P6zWz" +
            "rymv7sser5hcS3rAXmgi7yedE0WXXLydeMQTd6zs6d9qOhGcgykG/3UX1OYq6yol60Bcl0PH8lEGKsWH" +
            "Q4W0RGETV12VdWOaFz7rV4eZiK9ImvUt80kEB+apQ5PXF2132PxxMOTN93BB0cakCTTrXbdUV/hca9Oq" +
            "NAO/3nnw7RUgA1NmvN+DNTVuJ8KV5YUDnx7SNLS89QD8kuvzRIE0tctkypwDdaTA1nrCrHfT5GYMUoz/" +
            "obOGtV0CKXGcQ0E11Ov6PLIsIOWYkOeglH8BlQ/YI2jvflbPPDfST+o1uZ8YPLSWWpVpo0YoesJdCWFj" +
            "AoeFRJFZi8gRBnpPWa6eQ77HmoHF4c1PgTUDnktPpRtZZC/lD4sUfEy99J09nSVdT/qBj0zIOul+KsWH" +
            "Qnwy7oEeVeREBXhF0eUHofWIKuNjQ/zIJzvr7B+ytkYxzPLp+hyLsZYV3N83CRGHnemgbkLnOWo++zu5" +
            "Y19NugVSU3lzsK+8lacRaFVPQOSOYIeXAA3Q8ipDLoM8KoH94wX1tRr9+9NAY9KoG9E9fbWy3iytDORv" +
            "9XGYGsk6nLtXemWW+i3CifsV7GODlIn8d5GKfEX5M/MIrNwl27GHEJZbXdvPili/rEXhzrBHFin+v17E" +
            "Qfeo87bqwLCxC97uTibKTL3EUe8CLe4rqQOezohx0vyrGhkCHfX6xsW0XF3qTREZ0OTuaFTpqL4iKBBf" +
            "/2xts6jku0FXA8z04IRNusAuy0CTYUSkpbveignxZ2A3DD3An9mnTg46LSuyoINvb51odyIv9Vl1ZCE8" +
            "aeHlzGfSCol33vBSIyqAvWcagf9Mw6NCIj881vpHuqqD5ZLlQTNRvDotABmnHUJA34NVXLDdmKAsnqdx" +
            "EGeMFuThp4+fNofF3fOrLAbnJrnR32ea8D9mi9gOWPqy2uQ2S/EBf9AB9TgO6eBFMG+TSA4EuZ17ud9M" +
            "00HyigT2MrPrAZkl4LxnATQb6jdZ45YtOwohWEoLjOIEvG0BeUXj1ODckxgXDIX8odG9AmhArg5YT4UC" +
            "f14Aue/sZf9BfNAz6Ya+b6wyj0yuS1y9LwZ7Xjsi8/XNo0BuQMF7pNXHPo6hhl3eQwwbGn4+pIa/4BOs" +
            "c/iiaiYKLB3kX8rt5Wna72WIOuU62iKDPSKDPSaBPWvpcuhnomsyLDnQvnV6RnitLkC8KU8m+O0DEDPp" +
            "CjpaEesGOjW6XyPggD3+NtXkoCHekKDw44gKUvfLPhIMB7F6QrxhcvGuGwKPVxa8XkvbTi96bBfDUpkm" +
            "2Jaw+9wU90WTQ/XR6WXhOhK0gQe67x73VHK8+32M5q4qW2hQ59ha0ds7Y8zkK/JrQzHQ5UbsliXzxe0F" +
            "dVsgUeM4bGb1cCQK5eNyNeHRdpkWXbQmjz6cl0MXnpxjoLd5eveQL+k5GH5CWhStQhL0ggV6U4F+RNPq" +
            "S8LwoF2Lz6lZwCWOq203qQXRgm1glAsj58QcFPGzuvBHZMs0eVfqcg66bNIoE9DkJdHGqfEE4qCVhwkc" +
            "c9JKiVkNuHK/q6BS1V28G7FFYJJBL3XdN1oCuWOYzoVHLlmmhgnHOA3TNpNGzwKDLAakK9HmFly9Ivb9" +
            "NZ0n9MgdryQZBDwF7JeFtzQbcBHTEGas+d8H1pHkFYxBvHpVs0YE+yawnGSPo6JE3K3nwOQXoSwHLdsO" +
            "kyBoCP4RXbwb0fDOAeRLs4lGG28Sbl9JmUk+nw4PUtcQhW6YErlTefMLSTho9bxh05ExnJa+uAr3cQJF" +
            "XmCnstSbodVPgKw16bqzb5Ha5N2sXM+ZyxUuXm8K+1mRv7iVbZnxky7il7fESAHSPzAvKdFWgi/83niW" +
            "NwKtHCXscwDdiph5cq8kNYpoNj3GU9xiqSMmDckBvbjJJJAehXrIFoA81Ajpg1oGOMt0ZhX6aEySLVyF" +
            "SEPkStszUFHSx+i8s7HEBHxTwRiCXdbs4weS1y5wcM4mFeCayRbXXq5zQmPeRLUFAf6HsvZjyzrxgEuP" +
            "pJRd0UbIsSoskiqbyJWKvvpHSw+2XaZD3VA0DfVDwVX/fbMiDxjC8bLhui0WP41ftKVqW7gQFCXqdbBk" +
            "LoNG/Vf3ScEqfYvxyguj2jnr5Ylr7clJe3SSlVrc7m5TqDAN+pYHsiRHg0rhtGoyP5x6gAUFfTQbbOLe" +
            "iCG5Vu0QvGMgWgK5JL34tgn7oJV8m094BKUDHao8tBexBSneb6dXDQK7bR3NdhqMB6WPsraVxiWozXL/" +
            "j1VVGBmn07+XNiwG9OZctmkDUWXwhgt5N7HuvX8YbrbbUg44FyH9GQL/Tpwa9mV59IxXvCTfdOLaZdlq" +
            "Odz0Gb24qWyBZkpYW9O7a7S+QWPfZ6zNLvvg42hCgQi1JW/1+Qbz645Ha/htxevWThF1eVBDHAumwhWC" +
            "zFm26WWOpENZiZlPpepuUDAFiHzNM6PSkai3PrUWyNG3yzw2yJJvy34vWq320DHq3V8cunY0T2G+SNXz" +
            "jWfcLiV8SX7rmIIQDrDnwJLW+VDhrsUINxJn9sO1qHegM9qs6CXNmZ/YSWX1LOgXs350N1Jm9xPaNsj+" +
            "6AvZuE81+Zmd2yux73uLCCHQB+DEG/IuzQTyzUwz3tyxF3q3k2A90BfSHDPznXj3V/wjs+Sm1b9i5OU1" +
            "26Cx8iM66gzAbCnSDC6E74oMKamNRHs+Z/XDs/wOnLNA13FHpygAAAABJRU5ErkJggg==";//GetDefaultValueFromAttribute<Settings>("Image");
        }

        public static string GetDefaultValueFromAttribute<T>(string propertyName) {
            PropertyInfo propertyInfo = typeof(T).GetProperty(propertyName);
            if (propertyInfo == null) {
                throw new ArgumentException($"Property '{propertyName}' not found.", nameof(propertyName));
            }
            DefaultValueAttribute defaultValueAttr = propertyInfo.GetCustomAttribute<DefaultValueAttribute>();
            if (defaultValueAttr == null) {
                throw new InvalidOperationException($"No DefaultValueAttribute found for property '{propertyName}'.");
            }
            return (string)defaultValueAttr.Value;
        }
    }

}
