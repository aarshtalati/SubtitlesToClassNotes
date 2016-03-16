# SubtitlesToClassNotes
Converts standard subtitle files for each chapter of each lesson into a single text file

##Mac##

I do not have a Mac to test with but I noted that the default .gitignore actually adds DNX related files to exception list.On the flip side, when I was going through https://www.jeremymorgan.com/tutorials/vnext/how-to-build-c-sharp-on-mac-osx/ (*great post, you might want to skip to § 4*) I noticed the Project.json ( which is what you might be looking for ) but looks like it's needed for ASP.NET application (ASP.NET is a platform in .NET for writing Web Applications) not the stand-alone C# console application which runs on desktop computer - but I could be wrong. ( The crossed out links below are related to ASP.NET )


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
