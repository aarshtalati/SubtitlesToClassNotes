# Subtitles To ClassNotes
Converts standard subtitle files for each chapter of each lesson into a single text file
##Motivation##

So, I was looking at some online course, which come with subtitles. The website had a straighforward way to download the course video files and subtitle files (*.srt).

I noticed that ...

1. I was spending too much time in just typing what was being spoken to take my notes so now I can simply copy-paste 
2. Sometimes had to shuffle to multiple videos if I was looking for something in particular to refresh my memory so now I can open the text file and simply search to pin point the corresponding video clip in the course videos

 

Another positive side effect is it let's the student set the offsets of subtitles ( I actually, developed this capability to fine tune a French movie I was  watching and the only English subtitle were little off from what was being spoken )

## Assumption ##
The srt file follows the standard format.

## Caveat ##
Later it was found that not all srt files were formatted <a href="https://en.wikipedia.org/wiki/Timed_text#Example" target="_blank">exactly the same way</a>, and the program would not be able to match the pattern. Hence, more Regular Expressions were later added for other known variants.

## Configurations ##
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
  </tbody>
</table>



##Using on Mac##

I do not have a Mac to test with but I noted that the default .gitignore actually adds DNX related files to exception list.On the flip side, when I was going through ***[a great post,( you might want to skip to § 4 )](https://www.jeremymorgan.com/tutorials/vnext/how-to-build-c-sharp-on-mac-osx/)*** I noticed the Project.json ( which is what you might be looking for ) but looks like it's needed for ASP.NET application (ASP.NET is a platform in .NET for writing Web Applications) not the stand-alone C# console application which runs on desktop computer - but I could be wrong. ( The crossed out links below are related to ASP.NET )


I'd honestly try to make arrangements to see if I can manage to test this app on Mac - but not in the position to be able to promise you. I did some research and following links seemed helpful :


- [How to program C# on a Mac](https://www.youtube.com/watch?v=AHTY5QXbsn0)
- [Mono Project](http://www.mono-project.com/) --> [Installation Page](http://www.mono-project.com/docs/getting-started/install/)
- [Mono Develop](http://www.monodevelop.com/)
- [Mono Debugging](http://code.visualstudio.com/Docs/editor/debugging#_mono-debugging)
- <a href="http://yeoman.io/">Yeoman</a> - an application scaffolding tool, you can think of this as <strong>File</strong> &gt; <strong>New Project</strong> for VS Code
- [http://code.visualstudio.com/docs/editor/setup](http://code.visualstudio.com/docs/editor/setup)



- <del>http://www.infoq.com/news/2015/05/NET-Linux-Mac</del>
- <del>https://channel9.msdn.com/events/Build/2015/3-670 seems a good video, skip to 14:30</del>
- <del>https://www.youtube.com/watch?v=MnYKdqERGXs</del>
- <del>http://docs.asp.net/en/latest/getting-started/installing-on-mac.html</del>
- <del>http://i.imgur.com/4xvR2oC.png</del>


I'm planning to make it easier by building a [Docker](http://www.docker.com/ "Docker Homepage") container to make it easier for y'all.
