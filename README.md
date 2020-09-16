# Blazor JavaScript Embedder

> :warning: This is still work in progress

![Nuget Package](https://img.shields.io/nuget/v/BlazorJsEmbedder)

This repository allows you to write your JavaScript codes in razor file.

If you want run JavaScript codes at first render, you can use `JsEmbedder` component:

```html
<JsEmbedder
            @ref="ref"
            JavaScript="
                alert('Hello Blazor Javascript Embedder!')
           "/>
```

Also you can use `RunJsFunction<T>` method to run javascript functions inside your C# methods:

```csharp
JsEmbedder ref;
public async Task ButtonClick()
{
       var result = await ref.RunJsFunction<int>(@"
                (function() {
                    return 2 + 2;
                })()
            ");
}
```

## Why

This repository is not doing something magical. It just use `IJSRuntime`. But a separate javascript file can sometimes be too complex for small jobs. With Blazor JavaScript Embedder you can directly write your JavaScript code in same file with your razor code.

## Setup

There is no nuget package yet.

1. Add nuget package to project:

```
dotnet add package BlazorJsEmbedder
```

2. Add this script to end of \_Host.cshtml: 

```html
<script src="_content/BlazorJsEmbedder/index.js"></script>
```

## Known limitations

- You can't debug your code with ease. Because of that I suggest use this component for not complex javascript codes.

## Licensing

Licensed under the [MIT](https://github.com/ahmetcanaydemir/BlazorJavascriptEmbedder/blob/master/LICENSE).
