# hdx4vs
Haskell Extension for Visual Studio.  
This vsix is under development.

[]()
![02_quick_start.gif](https://raw.githubusercontent.com/phoityne/hdx4vs/master/docs/02_quick_start.gif)

## Depends

This vsix depends on these libraries. 
*  [language-haskell](https://github.com/JustusAdam/language-haskell)  
Currently, [syntaxes](https://github.com/JustusAdam/language-haskell/tree/master/syntaxes) files are included directly.  
Maybe, it is better that it should be vsix separated.

* [haskell-ide-engine](https://github.com/haskell/haskell-ide-engine)  
  It is the language server.
* debugging
  * [haskell-dap](https://github.com/phoityne/haskell-dap)
  * [haskell-debug-adapter](https://github.com/phoityne/haskell-debug-adapter)


## Limitations
* run on stack project.

## Features
under construction.  

## Setup
* hie  
```
> git clone https://github.com/haskell/haskell-ide-engine --recursive
> cd haskell-ide-engine
> stack install
```

* haskell-debugger
```
> stack install haskell-dap phoityne-vscode
```


