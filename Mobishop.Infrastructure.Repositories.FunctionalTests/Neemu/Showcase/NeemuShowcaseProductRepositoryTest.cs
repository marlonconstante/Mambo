﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Mobishop.Infrastructure.Framework.Repositories;
using Mobishop.Infrastructure.Repositories.Neemu.Showcase;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Repositories;

namespace Mobishop.Infrastructure.Repositories.FunctionalTests.Neemu.Showcase
{
    [TestFixture]
    public class NeemuShowcaseProductRepositoryTest
    {
        NeemuShowcaseProductRepository m_target;

        [SetUp]
        public void Setup()
        {
            var unitOfWork = new MemoryUnitOfWork();
            m_target = new NeemuShowcaseProductRepository(unitOfWork);
        }

        [Test]
        public async Task FindShowcaseProductByNameAsync_Carne_ShowcaseProductWithCarne()
        {
            var name = "carne";
            var actual = await m_target.FindShowcaseProductByNameAsync(name, Priorities.UserInitiated);

            Assert.That(actual.Select(p => p.Id), Has.All.GreaterThan(0L));
            Assert.That(actual.Select(p => p.Description.ToLower()), Has.All.Contains(name));
            Assert.That(actual.Select(p => p.PreviousPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.CurrentPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.ImageUrl), Has.All.Not.Empty);
        }

        [Test]
        public async Task FindShowcaseProductSugestionsByNameAsync_Carne_SuggestionsWithCarne()
        {
            var name = "carne";
            var actual = await m_target.FindShowcaseProductSugestionsByNameAsync(name, Priorities.UserInitiated);

            Assert.IsTrue(actual.Count() > 0);
            Assert.That(actual.Select(s => s.ToLower()), Has.All.Contains(name));
        }

        [Test]
        public async Task FindShowcaseProductSugestionsByNameAsync_XPTOXPO_EmptySuggestionList()
        {
            var name = "XPTOXPO";
            var actual = await m_target.FindShowcaseProductSugestionsByNameAsync(name, Priorities.UserInitiated);

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [Test]
        public async Task FindProductAndUseCacheToFindSuggestion_Carne_ProductsAndSuggestions()
        {
            var name = "carne";
            var actual = await m_target.FindShowcaseProductByNameAsync(name, Priorities.UserInitiated);

            Assert.That(actual.Select(p => p.Id), Has.All.GreaterThan(0L));
            Assert.That(actual.Select(p => p.Description.ToLower()), Has.All.Contains(name));
            Assert.That(actual.Select(p => p.PreviousPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.CurrentPrice), Has.All.GreaterThan(0d));
            Assert.That(actual.Select(p => p.ImageUrl), Has.All.Not.Empty);
       
            var actual2 = await m_target.FindShowcaseProductSugestionsByNameAsync(name, Priorities.UserInitiated);

            Assert.IsTrue(actual2.Count() > 0);
            Assert.That(actual2.Select(s => s.ToLower()), Has.All.Contains(name));
        }

    }
}
