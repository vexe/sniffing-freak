-What's This about?

*Sniffing freak is a C# winform app that is used to fetch/take data from removable drives quite fast.
 
-How do I sniff?

*Simple:
1-Select a loaction for your black box (the directory storing the files to be sniffed)
2-Add the formats (file extensions) that you want to sniff in the SniffingFormats textBox, then click Apply.
3-Now you can either manually sniff a drive by selecting it from the comboBox below and clicking on sniff
OR, click on GoSilent and the program window will disappear. Now, if you insert a flash drive, SniffingFreak will
automatically sniff it!

If you wanna bring the window back again, you'd have to go to the parent directory of your black box
and create a file called 'SilentMode.OFF' and the window will pop up again!

NOTE: you must create this file in the parent directory of your black box.
So if the black box is in your Desktop you have to create the 'SilentMode.OFF' file in the Desktop as well.

-What about the settings tab?

there are currently 2 settings:
1-Show on start up, which will start the program everytime you boot up and log in to windows.
2-SCIRD mode which stands for (Sniff Current Inserted Removable Drive), as I said before, when you're in silent mode
you'll ONLY sniff any new inserted drives, so if you had like 2 flashes already inserted, they won't get sniffed
SCIRD mode sniffs any currently inserted drives when you hit GoSilent.
