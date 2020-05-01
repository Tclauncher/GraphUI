## GraphUI | 运行方式

中文 | English

> GraphUI分为两部分，GraphUI.dll和GraphUI.exe。当然，任何懂一点c#知识的人都可以把他们打包进自己的程序。
>
> 两个模块间有两种通信方式：
>
> ​			Socket
>
> ​			MemoryMappedFile
>
> 默认选择第二种，因为他快。
>
> 可选第一种，这样就可以在其它计算机上显示界面（然而并没有什么用）
>
> GraphUI.exe是基于UpdateLayeredWindow的