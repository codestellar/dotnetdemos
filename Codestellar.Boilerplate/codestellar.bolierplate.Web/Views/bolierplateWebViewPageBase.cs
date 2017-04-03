using Abp.Web.Mvc.Views;

namespace codestellar.bolierplate.Web.Views
{
    public abstract class bolierplateWebViewPageBase : bolierplateWebViewPageBase<dynamic>
    {

    }

    public abstract class bolierplateWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected bolierplateWebViewPageBase()
        {
            LocalizationSourceName = bolierplateConsts.LocalizationSourceName;
        }
    }
}