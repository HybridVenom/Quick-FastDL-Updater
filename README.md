# Quick FastDL Updater
Quick and automatic FastDL updater. This application will compress maps (filtered by prefix) from your dedicated CS:GO server to given FastDL path.

## Releases
### v0.5-beta
[Download](https://github.com/HybridVenom/Quick-FastDL-Updater/releases/tag/v0.5-beta)

## Preview
A 30 second preview of [v0.5-beta](https://github.com/HybridVenom/Quick-FastDL-Updater/releases/tag/v0.5-beta)
![v0.5-beta Preview](https://i.imgur.com/q3sE4MN.gif)

## Todo and bugs 🐛
### Todo
- [x] Start: Get base program working (i.e compress maps to Bz2 (optional: filtered by prefix) -> add to FastDL maps folder)
- [x] Start: Run compression on second thread
- [x] Status text: Make the status text show what it is currently doing
- [ ] Status image: "Loading" gif
- [x] Progress bar: Get it working
- [ ] Application window: Make application window scale items correctly
- [x] Compression level: Add different levels of compression
- [ ] Help button: Add a help button :)
- [ ] Skip existing: Add an option to skip re-compressing already existing files in the FastDL directory.

### Known bugs 🐛
- [ ] Map prefix(es): `bhop/ar/cs/` -> Expected: filter by "bhop", "ar" and "cs". Result: 4th entry is empty, makes it count ALL files (inc. folders)

## Explanation of fields
- CS:GO Server path: The full path to the root of your dedicated CS:GO server ("root" is the folder that contains "srcds.exe")
- FastDL path / Output path: The full path to the root of your FastDL directory (this directory must contain a folder called "maps")
- Map prefix(es): Filter which maps you want compiled by typing the common prefix (ex. "bhop_" or "de_"). Supports multiple prefixes (separate with '/' ex. "bhop_/kz_")
- Pre-check: Validates your paths and tells you how many maps were found with used prefix.
- Start: Start compressing the maps and put the compressed files in given FastDL path.
