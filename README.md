# notification-banner

**Version:** 2.0.0.0  
**Authors:** Bluscream, Belphemur, Cursor AI

C# app to send custom Windows notifications, useful for alternate shells like [CairoDesktop](https://github.com/cairoshell/cairoshell) or automation scripts.

## Usage

You can run the app with either positional arguments or named arguments:

### Positional Arguments
```
banner.exe "Your message here" "Optional title here"
```
- If you provide one argument, it is used as the message.
- If you provide two arguments, they are used as message and title.

### Named Arguments
```
banner.exe --message "Your message" --title "Optional title" --image "image_path_or_base64" --position "topleft" --time 10
```
You can use any of the following prefixes for each argument: `--`, `-`, or `/` (e.g., `--message`, `-message`, `/message`).

#### Arguments
- `--message` (required if not using positional): The notification message
- `--title`: The notification title
- `--image`: Image path or base64 string
- `--position`: Banner position as a string (e.g., `topleft`, `topright`, `bottomleft`, `bottomright`, `topcenter`, `bottomcenter`, `center`)
- `--time`: Time to display notification (seconds)

### Example
```
banner.exe "Hello world!" "My Title"
banner.exe --message "Hello world!" --position "bottomright" --time 5
```

---
