# Subtitles To ClassNotes #
Converts standard subtitle files for each chapter of each lesson into a single text file. Version 2 just got released! [What's new?](https://github.com/ablaze8/SubtitlesToClassNotes/releases/tag/v2.0)

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

In v2.0 release, this application converted to .NET Core from .NET Framework. The legacy code is no longer actively being maintained. [v1.0](https://github.com/ablaze8/SubtitlesToClassNotes/releases) can be accessed from release tab or from [legacy](https://github.com/ablaze8/SubtitlesToClassNotes/tree/legacy) branch.

To install .NET core, go to https://www.microsoft.com/net/learn/get-started/

Commands:

`$ git clone https://github.com/ablaze8/SubtitlesToClassNotes.git`

`$ cd SubtitlesToClassNotes`

`$ dotnet build`

`$ dotnet run`
