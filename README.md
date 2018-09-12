# Subtitles To ClassNotes #
Converts standard subtitle files for each chapter of each lesson into a single text file
## <u>Motivation</u> ##

So, I was looking at some online course, which come with subtitles. The website had a straighforward way to download the course video files and subtitle files (*.srt).

I noticed that ...

1. I was spending too much time in just typing what was being spoken to take my notes so now I can simply copy-paste 
2. Sometimes had to shuffle to multiple videos if I was looking for something in particular to refresh my memory so now I can open the text file and simply search to pin point the corresponding video clip in the course videos

 

Another positive side effect is it let's the student set the offsets of subtitles ( I actually, developed this capability to fine tune a French movie I was  watching and the only English subtitle were little off from what was being spoken )

## <u>Assumption</u> ##
The srt file follows the standard format.

## <u>Caveat</u> ##
Later it was found that not all srt files were formatted <a href="https://en.wikipedia.org/wiki/Timed_text#Example" target="_blank">exactly the same way</a>, and the program would not be able to match the pattern. Hence, more Regular Expressions were later added for other known variants.

## <u>Configurations</u> ##
<table style="text-align: left; width: 100%;" cellpadding="2"
 cellspacing="2">
  <tbody>
    <tr>
      <th>Variable</th>
      <th>Function</th>
    </tr>
    <tr>
      <td>basePath</td>
      <td>Thisv is valid  root directory path string the where you've extracted your zip file containing subtitle dir and/or files</td>
    </tr>
    <tr>
      <td>condensed</td>
      <td>Could be True or False ( <a href="https://msdn.microsoft.com/en-us/library/c8f5xwh7.aspx?f=255&MSPPError=-2147217396" target="_blank">boolean</a> )</td>
    </tr>
    <tr>
      <td>verboseLogging</td>
      <td>Controls if you want to include tracing information related to Regualar Expressions ( <a href="https://msdn.microsoft.com/en-us/library/c8f5xwh7.aspx?f=255&MSPPError=-2147217396" target="_blank">boolean</a> )</td>
    </tr>
    <tr>
      <td>ignoreWarnings</td>
      <td>Controls if you want to surpress warnings related to Regualar Expressions ( <a href="https://msdn.microsoft.com/en-us/library/c8f5xwh7.aspx?f=255&MSPPError=-2147217396" target="_blank">boolean</a> )</td>
    </tr>
    <tr>
      <td>sortDirectoryNames</td>
      <td>Controls if you want to sort sub directories based on a delimeter ( <a href="https://msdn.microsoft.com/en-us/library/c8f5xwh7.aspx?f=255&MSPPError=-2147217396" target="_blank">boolean</a> )</td>
    </tr>
  </tbody>
</table>



## <u>Installation</u> ##

There are other branches, which use the full fledged .NET and run only with Visual Studio 2012 or later. If you are not using Visual Studio 2012+ or not familiar with .NET, .NET Core is your best bet. Just like Python and Java, .NET Core runs on Linux/Windows/Apple.

##### I highly recommend using the .NET Core instead the .NET branches for the easiest installation. Installation instructions could be found at: https://www.microsoft.com/net/core/

If you are familiar with .NET and know what you are doing, feel free to use other branches.

##### Clone command:
`git clone -b dotNetCore --single-branch https://github.com/ablaze8/SubtitlesToClassNotes.git`

##### I highly recommend using Visul Studio Code to edit the code. It's free and runs on Linux/Windows/Apple. https://code.visualstudio.com/

Open `Program.cs`, change `basePath` variable accordingly. VS Code might ask you to install C# extension and to restore packages - say yes. Reload your VS Code. Click the green "play" icon and a text file called "Notes.txt" should have created at the path you mentioned for `basePath` variable.
