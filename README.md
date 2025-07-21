# notification-banner

C# app to send custom windows notifications in case you're using a alternate shell like [CairoDesktop](https://github.com/cairoshell/cairoshell) or something :)

## Usage
```batch
notification-banner.exe --message "notification message" --title "notification title" --image "image_path_or_base64" --position 1 --time 10
```

You can use any of the following prefixes for each argument: `--`, `-`, or `/` (e.g., `--message`, `-message`, `/message`).

- `--message` (required): The notification message
- `--title`: The notification title
- `--image`: Image path or base64 string
- `--position`: Banner position (enum value or int)
- `--time`: Time to display notification (seconds)
