﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Codebase.Website.Models;
using System.IO;

namespace Codebase.Website.Controllers
{
    public class menuController : Controller
    {
        public ActionResult WebsiteMenu(string menuSliderPartialView, string partialView, bool showSlider)
        {
            MenuViewModel menuViewModel = new MenuViewModel();
            menuViewModel.ShowSlider = showSlider;
            menuViewModel.MenuPartialView = partialView;
            menuViewModel.MenuSliderPartialView = menuSliderPartialView;

            if (showSlider)
            {
                string theme = "5E1A2906-F51C-4915-84D1-5FD49ED9C18B";
                string path = Path.Combine(Server.MapPath("~/Content/" + theme + "/menu/"), partialView.ToLower());

                List<LinkTag> imageList = new List<LinkTag>();

                foreach (string image in Directory.GetFiles(path, "*.jpg"))
                {
                    LinkTag linkTag = new LinkTag();

                    linkTag.Src = "/" + image.Substring(Server.MapPath("~").Length).Replace("\\", "/");

                    imageList.Add(linkTag);                    
                }                

                menuViewModel.ImageList = imageList;
            }

            return PartialView(menuViewModel.MenuPartialView, menuViewModel);
        }

        public ActionResult WebsiteMenu2(string menuSliderPartialView, string partialView, bool showSlider, string maparea)
        {
            MenuViewModel menuViewModel = new MenuViewModel();
            menuViewModel.ShowSlider = showSlider;
            menuViewModel.MenuPartialView = partialView;
            menuViewModel.MenuSliderPartialView = menuSliderPartialView;

            if (showSlider)
            {
                string theme = "5E1A2906-F51C-4915-84D1-5FD49ED9C18B";
                string path = Path.Combine(Server.MapPath("~/Content/" + theme + "/menu/"), partialView.ToLower());

                List<LinkTag> imageList = new List<LinkTag>();

                string[] images = Directory.GetFiles(path, "*.jpg");
                string[] mapareas = new string[0];

                if (!string.IsNullOrEmpty(maparea))                
                    mapareas = maparea.Split('|');                

                for(int i = 0; i < images.Length; i++)
                {
                    LinkTag linkTag = new LinkTag();

                    linkTag.Src = "/" + images[i].Substring(Server.MapPath("~").Length).Replace("\\", "/");

                    if (mapareas.Length > 0 && i < mapareas.Length)
                        linkTag.Usemap = mapareas[i];

                    imageList.Add(linkTag);
                }

                menuViewModel.ImageList = imageList;
            }

            return PartialView(menuViewModel.MenuPartialView, menuViewModel);
        }

    }
}
