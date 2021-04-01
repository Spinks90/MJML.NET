using AngleSharp.Dom;
using MjmlDotNet.Components.Attributes;
using MjmlDotNet.Core.Components;
using MjmlDotNet.Core.Helpers;
using System.Collections.Generic;


namespace MjmlDotNet.Components.Mjml.Body
{
    internal class MjmlTableComponent : BodyComponent
    {
        public MjmlTableComponent(IElement element, BaseComponent parent) : base(element, parent)
        {
        }

        public override Dictionary<string, string> SetAllowedAttributes()
        {
            return GlobalDefaultAttributes.Body.MjmlTable;
        }

        public override void SetupStyles()
        {
            // LR: Add styles
            StyleLibraries.AddStyleLibrary("table", new Dictionary<string, string>() {
                { "color", GetAttribute("color") },
                { "font-family", GetAttribute("font-family") },
                { "font-size", GetAttribute("font-size") },
                { "line-height", GetAttribute("line-height") },
                { "table-layout", GetAttribute("table-layout") },
                { "width", GetAttribute("width") },
                { "border", GetAttribute("border") },
            });
        }

        private string GetWidth()
        {
            string width = GetAttribute("width");
            CssParsedUnit parsedWidth = CssUnitParser.Parse(width);

            return parsedWidth.Unit == "%" ? width : $"{parsedWidth.Value}px";
        }

        public override string RenderMjml()
        {
            string content = Element.Html();
            return $@"
            <table {HtmlAttributes(new Dictionary<string, string> {
                    { "style", "table" },
                    { "cellpadding", GetAttribute("cellpadding") },
                    { "cellspacing", GetAttribute("cellspacing") },
                    { "width", GetWidth() }
                 })}>
                { RenderChildren() }
            </table>
            ";
        }
    }
}
