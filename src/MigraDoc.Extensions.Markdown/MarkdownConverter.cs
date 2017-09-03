using MigraDoc.DocumentObjectModel;
using MigraDoc.Extensions.Html;
using System;
using Markdig;

namespace MigraDoc.Extensions.Markdown
{
    public class MarkdownConverter : IConverter
    {
        public Action<Section> Convert(string contents)
        {
            var pipeline = new MarkdownPipelineBuilder().UseEmphasisExtras().Build();
            var html = Markdig.Markdown.ToHtml(contents, pipeline);

            var htmlConverter = new HtmlConverter();
            return htmlConverter.Convert(html);
        }
    }
}
