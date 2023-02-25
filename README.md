## This repository is a reproduction example for dotnet/aspnetcore#46747.

Run the application, and see that the contents of `<header>` did not change color.
The issue is caused by the HTML markup missing the unique attribute that is present
in the CSS output.

```html
<body>
<header>
    Some content!
</header>

<main role="main">
    
Page content

</main>

<footer b-l2lt595hg5>
    Some content!
</footer>
</body>
```

```css
/* _content/header-tag-css-isolation-repro/Pages/Shared/_Footer.cshtml.rz.scp.css */
footer[b-l2lt595hg5] {
    color: red;
}
/* _content/header-tag-css-isolation-repro/Pages/Shared/_Header.cshtml.rz.scp.css */
header[b-xpdrcjprha] {
    color: red;
}
```

Adding the tag helper opt-out `<!header>` results in a skewed up HTML output:
```html
<body>
< b-xpdrcjprhaheader>
    Some content!
</header>

<main role="main">
    
Page content

</main>

<footer b-l2lt595hg5>
    Some content!
</footer>
</body>
```

**UPDATE**: The `<form>` element also seems not to work with CSS isolation.
The `<label>` and `<input>` elements only work if you do not apply the `asp-for=""` tag helper. 
```html
<form>
    The form element is also not supported, regardless you apply tag helpers or do not
    <label b-yate93u0ku for="works">This is a label that works!</label>
    <input b-yate93u0ku id="works" type="text" value="This works fine"/>
    <!-- The below elements have applied asp-for tag helpers -->
    <label for="SomeProperty">This label does not work</label>
    <input type="text" data-val="true" data-val-required="The This label does not work field is required." id="SomeProperty" name="SomeProperty" value="This input does not work" />
    <label for="ThisDoesNotWorkEither">ThisDoesNotWorkEither</label>
    <input type="text" data-val="true" data-val-required="The ThisDoesNotWorkEither field is required." id="ThisDoesNotWorkEither" name="ThisDoesNotWorkEither" value="Neither does this input filed" />
</form>
```

```css
/* _content/header-tag-css-isolation-repro/Pages/Index.cshtml.rz.scp.css */
form[b-yate93u0ku] {
    color: red;
}

label[b-yate93u0ku] {
    color: red;
}

input[b-yate93u0ku] {
    color: red;
}
```