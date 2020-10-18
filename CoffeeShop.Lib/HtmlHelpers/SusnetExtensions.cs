namespace CoffeeShop.Lib.HtmlHelpers
{
    using System.Web.Mvc;

    public static class SusnetExtensions
    {
        #region Public Methods and Operators

        public static MvcHtmlString SusnetCounter(this HtmlHelper htmlHelper, string counterId)
        {
            if (string.IsNullOrEmpty(counterId))
            {
                return MvcHtmlString.Empty;
            }

            return new MvcHtmlString(
                $@"<!-- START Susnet BESÖKSREGISTRERINGSKOD -->
<script type=""text/javascript"">
    var susnet_counter_id = {counterId};

    window.updateSusnetCounter = function() {{
        var $body = $(window.document.body);
        var $script = $(document.createElement(""script""));
        $script.appendTo($body);
        $script.on(""load"", function() {{ $script.remove(); }});
        $script.attr(""type"", ""text/javascript"")
            .attr(""src"", 'https://susnet.nu/stat?action=add&id=' + susnet_counter_id + '&sizex=' + screen.width + '&sizey=' + screen.height + '&referer=' + escape(document.referrer) + '&url=' + escape(window.location.href));
    }}
</script>
<!--SLUT Susnet BESÖKSREGISTRERINGSKOD -->
            "
                );
        }

        #endregion
    }
}
