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

**UPDATE**: The `form` element also seems not to work with CSS isolation:
```html
<form>
The form element is also not supported, regardless you apply tag helpers or do not
</form>
```

```css
/* _content/header-tag-css-isolation-repro/Pages/Index.cshtml.rz.scp.css */
form[b-yate93u0ku] {
    color: red;
}
```