using System.Web;
using System.Web.Optimization;

namespace projet_dot_net
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/creative/vendor/jquery/jquery.min.js",
                      "~/Content/creative/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Content/creative/vendor/jquery-easing/jquery.easing.min.js",
                      "~/Content/creative/vendor/scrollreveal/scrollreveal.min.js",
                      "~/Content/creative/vendor/magnific-popup/jquery.magnific-popup.min.js",
                      "~/Content/creative/js/creative.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/creative/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/creative/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/creative/vendor/magnific-popup/magnific-popup.css",
                      "~/Content/creative/css/creative.min.css"
                      ));
        }
    }
}
