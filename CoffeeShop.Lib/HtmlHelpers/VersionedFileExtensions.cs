namespace CoffeeShop.Lib.HtmlHelpers
{
    using System;
    using System.Web.Caching;
    using System.Web.Mvc;

    public static class VersionedFileExtensions
    {
        #region Public Methods and Operators

        public static MvcHtmlString VersionedFile(this HtmlHelper helper, string filename)
        {
            var versionedFilename = GetVersion(helper, filename);
            return MvcHtmlString.Create(versionedFilename);
        }

        #endregion

        #region Methods

        private static string GetVersion(this HtmlHelper helper, string filename)
        {
            var context = helper.ViewContext.RequestContext.HttpContext;

            // Look for a cached value.
            var cachedValue = context.Cache[filename];
            if (cachedValue != null)
            {
                return cachedValue as string;
            }

            // Cache did not exist. Refresh it.
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var resolvedFilename = urlHelper.Content(filename);
            var physicalPath = context.Server.MapPath(resolvedFilename);
            var version = "?v=" + new System.IO.FileInfo(physicalPath).LastWriteTime.ToString("yyyyMMddHHmmss");
            cachedValue = resolvedFilename + version;

            // Save new value to cache.
            context.Cache.Add(filename, cachedValue, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero, CacheItemPriority.Normal, null);

            return (string)cachedValue;
        }

        #endregion
    }

}
