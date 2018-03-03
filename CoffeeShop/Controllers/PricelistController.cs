namespace CoffeeShop.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using CoffeeShop.Models;

    public class PricelistController : Controller
    {
        #region Static Fields

        private static readonly List<PricelistItem> Pricelist;

        #endregion

        #region Constructors and Destructors

        static PricelistController()
        {
            Pricelist = new List<PricelistItem>
                        {
                            new PricelistItem
                            {
                                Name = "Garanterat Certifierat",
                                Price1Low = 179,
                                Price2Low = 189,
                                Price3Low = 209,
                                Description =
                                    "Mörkt mellanrostat kaffe från Bali blandat med ljust mellanrostat kaffe från Papua Nya Guinea. Certifierad Ekologisk, Fair-Trade och Rainforest Alliance. Hela bönor."
                            },
                            new PricelistItem
                            {
                                Name = "Dubbelknäppt",
                                Price1Low = 159,
                                Price2Low = 169,
                                Price3Low = 199,
                                Description =
                                    "Mörkt rostat kaffe från Brasilien och mellanrostat Red Bourbon från Rwanda blandat med mellanrostad Robusta Cherry från Indien. Hela bönor."
                            },
                            new PricelistItem
                            {
                                Name = "Dubbelknäppt Plus",
                                Price1Low = 149,
                                Price2Low = 159,
                                Price3Low = 189,
                                Description =
                                    "Mycket mörkt rostat kaffe från Brasilien blandat med Robusta Cherry från Indien. Hela bönor."
                            },
                            new PricelistItem
                            {
                                Name = "Välpackat",
                                Price1Low = 139,
                                Price2Low = 149,
                                Price3Low = 179,
                                Description =
                                    "Vårt experimentkaffe i ständig förvandling. Hela bönor."
                            },
                            new PricelistItem
                            {
                                Name = "Nordväst",
                                Price1Low = 199,
                                Price2Low = 209,
                                Price3Low = 239,
                                Description =
                                    "Mellanrostat kaffe från Honduras*. Camelo Puro Coop. Agropecuaria Quiraguira. Fair-Trade och Ekologisk. Hela bönor."
                            },
                            new PricelistItem
                            {
                                Name = "Nordost",
                                Price1Low = 269,
                                Price2Low = 279,
                                Price3Low = 309,
                                Description =
                                    "Mellanrostat kaffe från Rwanda*. Red Bourbon. Direct Trade. Hela bönor."
                            },
                            new PricelistItem
                            {
                                Name = "Sydost",
                                Price1Low = 189,
                                Price2Low = 199,
                                Price3Low = 229,
                                Description =
                                    "Mellanrostat kaffe från Bali*. Tri Hita Karana. Hela bönor"
                            },
                            new PricelistItem
                            {
                                Name = "Sydväst",
                                Price1Low = 189,
                                Price2Low = 199,
                                Price3Low = 229,
                                Description =
                                    "Mörkrostat kaffe från Peru*. Fair-Trade och Ekologisk. Cooperativa Aproexport. Hela bönor."
                            },
                            new PricelistItem
                            {
                                Name = "Kärnkaffe Skånerost",
                                Price1Low = 79,
                                Price1High = 111,
                                Price2Low = 89,
                                Price2High = 121,
                                Price3Low = 119,
                                Price3High = 151,
                                Description =
                                    "Mörkrostat kaffe från Brasilien, Colombia och Kenya. Malet kaffe."
                            },
                            new PricelistItem
                            {
                                Name = "Kärnkaffe Eko ft mörkrost",
                                Price1Low = 99,
                                Price1High = 129,
                                Price2Low = 109,
                                Price2High = 139,
                                Price3Low = 139,
                                Price3High = 169,
                                Description =
                                    "Mörkrostat kaffe från centralamerika. Malet kaffe."
                            },
                            new PricelistItem
                            {
                                Name = "Kärnkaffe Mellanrost",
                                Price1Low = 79,
                                Price1High = 111,
                                Price2Low = 89,
                                Price2High = 121,
                                Price3Low = 119,
                                Price3High = 151,
                                Description =
                                    "Mellanrostat kaffe från Brasilien, Colombia och Kenya. Malet kaffe."
                            },
                            new PricelistItem
                            {
                                Name = "Kärnkaffe Express",
                                Description =
                                    "NY SORT. Kommer snart! Mycket mörkt rostat kaffe från Brasilien och Indien."
                            }
                        };
        }

        #endregion

        #region Public Methods and Operators

        public ActionResult Index()
        {
            return View(Pricelist);
        }

        #endregion
    }
}