# RecipeSolution

使用控制台程序读取json格式的GTM配方，计算可能产生的冲突

## Project Setup

1.使用KubeJS导出配方
```sh
kubejs export
```

2.修改Program.cs中GetRecipes()方法的读取路径，需要提供装配线的所有配方文件路径以及自定义的部分配方文件路径，
例如想在某一个样板供应器中放置的样板对应的配方文件

## Todo

适配更多机器类型
