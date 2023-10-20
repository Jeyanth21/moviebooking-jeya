using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieTicketBooking.Business.Service;
using MovieTicketBooking.Controllers;
using MovieTicketBooking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBookingTests
{
    internal class MovieControllerTests
    {
        private Mock<IMovieService> _mockrepo;
        private MovieController _controller;

        [SetUp]
        public void Initialize()
        {
            _mockrepo = new Mock<IMovieService>();
            _controller = new MovieController(_mockrepo.Object);
        }
        [Test]
        public async Task GetMovie()
        {
            Movie movie = new Movie();
            string m;
          _mockrepo.Setup(x => x.GetMovie(It.IsAny<string>())).ReturnsAsync(movie);
          var Result= _controller.GetMovie();

            Assert.IsNotNull(Result);
        }      
        
    }
}
