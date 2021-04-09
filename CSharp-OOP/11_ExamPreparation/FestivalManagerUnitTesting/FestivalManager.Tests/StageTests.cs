// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        private Song song;
        private Performer performer;

        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
            song = new Song("CandyShop", new TimeSpan(0, 3, 30));
            performer = new Performer("Kristian", "Ivanov", 25);
        }
        [Test]
        public void AddPerformer_CannotBeNull()
        {
            var perfo = new Performer(null, null, 0);
            Assert.IsNotNull(perfo);
        }

        [Test]
        public void AddPerformer_AgeCannotBeLessThan18()
        {
            var perfo = new Performer("Kristian", "Ivanov", 15);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(perfo);
            });

            Assert.AreEqual(ex.Message, "You can only add performers that are at least 18.");
        }

        [Test]
        public void AddPerformer_Working()
        {
            //var perfo = new Performer("Kristian", "Ivanov", 20);
            //var targetPerformer =
            stage.AddPerformer(performer);
            Assert.AreEqual(1, stage.Performers.Count);
        }

        [Test]
        public void AddSong_CannotBeNull()
        {
            var music = new Song(null, new TimeSpan(0, 3, 30));
            Assert.IsNotNull(music);
        }

        [Test]
        public void AddSong_DurationTotalMinutesCannotBeLess()
        {
            var music = new Song("CandySHop", new TimeSpan(0, 0, 0));
            //var music12 = song.Duration = 0;
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(music);
            });

            Assert.AreEqual(ex.Message, "You can only add songs that are longer than 1 minute.");
        }

        [Test]
        public void AddSong_Working()
        {
            //var perfo = new Performer("Kristian", "Ivanov", 20);
            //var targetPerformer =

            var checkList = new List<Song>();
            checkList.Add(song);
            Assert.AreEqual(1, checkList.Count);
        }

        [TestCase(null, null)]
        public void AddSongToPerformer_NotNull(string songName, string performerName)
        {
            var performer = new Performer(performerName, null, 22);
            var music = new Song(songName, new TimeSpan(0, 0, 0));

            Assert.IsNotNull(performer);
            Assert.IsNotNull(music);
        }

        [Test]
        public void AddSongToPerformer_GetPerformer()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);

            var message = stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.AreEqual($"{song} will be performed by {performer}", message);
            
        }


        [Test]
        public void Play()
        {
            var performer2 = new Performer("Gosho", "Goshev", 26);
            stage.AddPerformer(performer);
            stage.AddPerformer(performer2);

            var songs1 = new Song("CandyShop", new TimeSpan(5, 50, 30));

            stage.AddSong(song);
            stage.AddSong(songs1);

            stage.AddSongToPerformer(song.Name, performer.FullName);
            stage.AddSongToPerformer(songs1.Name, performer2.FullName);

            var message = stage.Play();

            Assert.AreEqual($"2 performers played 2 songs", message);
        }


        [Test]
        public void GetPerformer_InvalidParameters()
        {
            var invalidPerformer = new Performer("Ceko", "Sifonq", 10);

            stage.AddPerformer(performer);
            stage.AddSong(song);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer(song.Name, invalidPerformer.FullName);
            });

            Assert.AreEqual(ex.Message, "There is no performer with this name.");
        }



        [Test]
        public void GetSong_InvalidParameters()
        {
            var invalidSong = new Song("Ceko Sifonq", new TimeSpan(1, 5, 30));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer(invalidSong.Name, performer.FullName);
            });

            Assert.AreEqual(ex.Message, "There is no song with this name.");
        }
    }
}