using Microsoft.AspNetCore.Razor.TagHelpers;
using OzenProje.ToDo.Business.Interfaces;
using OzenProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzenProje.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("getirGorevAppUserId")]
    public class GorevAppUserIdTagHelper : TagHelper
    {
        private readonly IGorevService _gorevService;
        public GorevAppUserIdTagHelper(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Gorev> gorevler = _gorevService.GetirileAppUserId(AppUserId);
            int tamamlananGorevSayisi = gorevler.Where(I => I.Durum).Count();
            int ustundeCalistigiGorevsayisi = gorevler.Where(I => !I.Durum).Count();

            string htmlString = $"<strong>Tamamladığı görev sayısı :</strong>" +
                $"{tamamlananGorevSayisi} <br> <strong>Üstünde çalıştığı görev sayısı :</strong>" +
                $"{ustundeCalistigiGorevsayisi} ";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
