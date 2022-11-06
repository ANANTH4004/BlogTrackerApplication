﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using BlogTrackerMVC.Models;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace BlogTrackerMVC.Controllers
{
    public class HomeController : Controller
    {
       
        string BaseUrl = "https://localhost:44365/api/";
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            List<Admin> blogs = new List<Admin>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("admin");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<Admin[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        blogs.Add(new Admin { Email =item.Email , Password = item.Password });
                    }
                }
            }
            var found = blogs.Find(x => x.Email == Request["Username"]);
            if(found != null)
            {
                if(found.Password == Request["password"])
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.msg = "Incorrect Paasword";
                }
            }
            else
            {
                ViewBag.msg = "Account Not Found";
            }
            return View();
        }
        public ActionResult Index()
        {
            List<Blog> blogs = new List<Blog>();
            using(var client  = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("blog");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<Blog[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        blogs.Add(new Blog { BlogId = item.BlogId, BlogUrl = item.BlogUrl, DateOfCreation = item.DateOfCreation, Email = item.Email, Subject = item.Subject, Title = item.Title });
                    }
                }
            }
            return View(blogs);
        }
        public ActionResult Show()
        {
            List<Blog> blogs = new List<Blog>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("blog");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<Blog[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        blogs.Add(new Blog { BlogId = item.BlogId, BlogUrl = item.BlogUrl, DateOfCreation = item.DateOfCreation, Email = item.Email, Subject = item.Subject, Title = item.Title });
                    }
                }
            }
            return View(blogs);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44365/api/blog");

                var blog1 = new Blog {BlogId = blog.BlogId , BlogUrl = blog.BlogUrl , DateOfCreation = blog.DateOfCreation , Email = blog.Email , Subject = blog.Subject , Title = blog.Title};

                var postTask = client.PostAsJsonAsync<Blog>(client.BaseAddress,blog1);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtaskResult = result.Content.ReadAsAsync<Blog>();
                    readtaskResult.Wait();
                    var dataInserted = readtaskResult.Result;
                }
            }

            return RedirectToAction("Index");
            
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}