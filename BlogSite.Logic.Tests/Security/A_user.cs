﻿using System;
using BlogSite.Entities;
using BloggingServices.Services;
using NUnit.Framework;
using FluentAssertions;
using Repositories.Abstractions;

namespace BlogSite.Logic.Tests.Security
{
    [TestFixture(Category = "A_user and Security Tests")]
    public class A_user
    {
        [Test]
        public void Can_be_created()
        {
            var user = SecurityHelper.CreateUser();
            user.Should().NotBeNull();
        }

        [Test]
        public void Can_log_in_using_username_and_password()
        {
            var username = "a@a";
            var password = "a";
            var repo = new InMemoryRepository<User>(SecurityHelper.GetUserList());
            var userService = new UsersService(repo);
            var user = userService.LoginUser(username, password);
            user.LoggedIn.Should().BeTrue();
        }

        [Test]
        public void If_a_user_cant_log_in_logged_in_property_of_the_user_should_be_false()
        {
            var username = "x@a";
            var password = "x";
            var repo = new InMemoryRepository<User>(SecurityHelper.GetUserList());
            var userService = new UsersService(repo);
            var user = userService.LoginUser(username, password);
            user.LoggedIn.Should().BeFalse();
        }
        
    }
}
