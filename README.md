*Mom get the Camera*

![image](https://github.com/tomdavies98/MGC/assets/11966780/07eec3a7-ef2b-4c0c-9ef1-58cec9f98d85)

MGC is a screen recording software. It's a GUI wrapper based on the ScreenRecorderLib package https://github.com/sskodje/ScreenRecorderLib
Although in it's current state it can start/stop recordings with some of the base feature of ScreenRecorderLib, it is a work in progress.

Planned features:
- Screen select (allow user to choose which monitor to record from eg 1,2,3. Currently it defaults to screen 1).
- Shadow Recording [if implementation of screenRecorderLib allows for the recording buffer to be limited to eg 5 min window (removing recorded frames older than 5 mins long)]
- Macros [Allowing users to start/stop recordings etc from self assigned macros stored in seperate json config locally]
- Update app icon
- Add notifications [possibly toast notification popups to update users in full screen applications without the need for direct UI interaction]
- Investigate long processing time after recording has been stopped (35 min recording took 10 minutes to process/save)
