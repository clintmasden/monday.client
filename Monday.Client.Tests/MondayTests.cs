using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monday.Client.Dtos;

namespace Monday.Client.Tests
{
    [TestClass]
    public class MondayTests
    {
        private static MondayClient _mondayClient;

        [ClassInitialize]
        public static void SetupClient(TestContext con)
        {
            _mondayClient = new MondayClient("APIKEY");
        }

        [TestMethod]
        public void User_GetUserById_Pass()
        {
            var result = _mondayClient.GetUserById(5412166).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void User_GetUserPosts_Pass()
        {
            var result = _mondayClient.GetUserPosts(5412166).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void User_GetUserNewsfeed_Pass()
        {
            var result = _mondayClient.GetUserNewsfeed(5412166).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void User_GetUnreadNewsfeed_Pass()
        {
            var result = _mondayClient.GetUserUnreadNewsfeed(5412166).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void User_GetUserList_Pass()
        {
            var result = _mondayClient.GetUsers().Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Board_GetBoardById_Pass()
        {
            var result = _mondayClient.GetBoardById(137872223).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Board_GetBoardList_Pass()
        {
            var result = _mondayClient.GetBoards().Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Board_CreateBoard_Pass()
        {
            var boardDto = new BoardDto
            {
                BoardType = BoardDto.BoardTypes.Public,
                Description = "Unit Test: A New board created through API",
                Name = "Unit Test: API Board",
                UserId = 5412166
            };

            var result = _mondayClient.CreateBoard(boardDto).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Board_DeleteBoard_Pass()
        {
            try
            {
                _mondayClient.DeleteBoard(137872223).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_UpdateTextColumn_Pass()
        {
            var columnDto = new BoardColumnTextDto
            {
                PulseId = 143083605,
                Text = "Unit Test Text Column"
            };

            try
            {
                _mondayClient.UpdateBoardTextColumn(137872223, "text9", columnDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_UpdatePersonColumn_Pass()
        {
            var columnDto = new BoardColumnPersonDto
            {
                PulseId = 143083605,
                UserId = 5412166
            };

            try
            {
                _mondayClient.UpdateBoardPersonColumn(137872223, "person", columnDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_UpdateStatusColumn_Pass()
        {
            var columnDto = new BoardColumnStatusDto
            {
                PulseId = 143083605,
                ColorId = 0
            };

            try
            {
                _mondayClient.UpdateBoardStatusColumn(137872223, "status", columnDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_UpdateDateColumn_Pass()
        {
            var columnDto = new BoardColumnDateDto
            {
                PulseId = 143083605,
                Date = "2018-10-25"
            };

            try
            {
                _mondayClient.UpdateBoardDateColumn(137872223, "date8", columnDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_UpdateNumericColumn_Pass()
        {
            var columnDto = new BoardColumnNumericDto
            {
                PulseId = 143083605,
                Value = 1
            };

            try
            {
                _mondayClient.UpdateBoardNumericColumn(137872223, "numbers1", columnDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_UpdateTagColumn_Pass()
        {
            var columnDto = new BoardColumnTagDto
            {
                PulseId = 143083605,
                Tags = "#UnitTest"
            };

            try
            {
                _mondayClient.UpdateBoardTagColumn(137872223, "tags3", columnDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_UpdateTimelineColumn_Pass()
        {
            var columnDto = new BoardColumnTimelineDto
            {
                PulseId = 143083605,
                InDate = "2018-10-25",
                OutDate = "2018-10-26"
            };

            try
            {
                _mondayClient.UpdateBoardTimelineColumn(137872223, "timeline", columnDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_CreateGroup_Pass()
        {
            var groupDto = new GroupDto
            {
                Title = "Unit Test Group"
            };

            try
            {
                _mondayClient.CreateGroup(137872223, groupDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_UpdateGroup_Pass()
        {
            var groupDto = new GroupDto
            {
                GroupId = "unit_test_group",
                Title = "Unit Test Group Updated",
                Color = "037f4c"
            };

            try
            {
                _mondayClient.CreateGroup(137872223, groupDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_DeleteGroup_Pass()
        {
            try
            {
                _mondayClient.DeleteGroup(137872223, "unit_test_group").Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_MoveGroup_Pass()
        {
            var groupDto = new GroupMoveDto
            {
                DestinationBoardId = 137870199,
                UserId = 5412166
            };

            try
            {
                _mondayClient.MoveGroup(137872223, "unit_test_group77", groupDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_GetPulsesByBoardId_Pass()
        {
            var result = _mondayClient.GetPulsesByBoardId(137872223).Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Board_GetSubscribersList_Pass()
        {
            try
            {
                var result = _mondayClient.GetSubscribersByBoardIdAsync(137872223).Result;
                Assert.IsTrue(result.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_CreateSubscriber_Pass()
        {
            try
            {
                var subscriberDto = new SubscriberDto
                {
                    AsAdmin = 0,
                    UserId = 4939512
                };

                _mondayClient.CreateSubscriberOnBoard(137872223, subscriberDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Board_DeleteSubscriber_Pass()
        {
            try
            {
                _mondayClient.DeleteSubscriberOnBoard(137872223, 4939512).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_GetPulseById_Pass()
        {
            var result = _mondayClient.GetPulseById(125377997).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Pulse_GetPulseList_Pass()
        {
            var result = _mondayClient.GetPulses().Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Pulse_GetPulseListByCriteria_Pass()
        {
            var result = _mondayClient.GetPulses(500, DateTime.Today, DateTime.Today).Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Pulse_GetUpdatesByPulseId_Pass()
        {
            var result = _mondayClient.GetUpdatesByPulseId(137483251).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Update_GetUpdateList_Pass()
        {
            var result = _mondayClient.GetPulses().Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Pulse_CreatePulse_Pass()
        {
            var pulseDto = new PulseDto
            {
                UserId = 5412166,
                Pulse = new PulseDto.PulseProperties { Name = "Unit Test Pulse" },
                Update = new PulseDto.UpdateProperties { Text = "Unit Test Update" },
                GroupId = "unit_test_group77"
            };

            var result = _mondayClient.CreatePulse(137870199, pulseDto).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Pulse_UpdatePulse_Pass()
        {
            var pulseDto = new PulseDto.PulseProperties
            {
                Name = "Unit Test Pulse - Update"
            };

            var result = _mondayClient.UpdatePulse(143083605, pulseDto).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Pulse_DeletePulse_Pass()
        {
            try
            {
                _mondayClient.DeletePulse(143345113).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_LikeUpdate_Pass()
        {
            try
            {
                var updateLikeDto = new UpdateLikeDto { UserId = 5412166 };

                _mondayClient.CreateLikeOnPulseUpdate(229899909, updateLikeDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_UnLikeUpdate_Pass()
        {
            try
            {
                var updateLikeDto = new UpdateLikeDto { UserId = 5412166 };

                _mondayClient.CreateUnLikeOnPulseUpdate(229899909, updateLikeDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_GetSubscribersList_Pass()
        {
            try
            {
                var result = _mondayClient.GetSubscribersByPulseIdAsync(157543293).Result;
                Assert.IsTrue(result.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_CreateSubscriber_Pass()
        {
            try
            {
                var subscriberDto = new SubscriberDto
                {
                    AsAdmin = 0,
                    UserId = 4939512
                };

                _mondayClient.CreateSubscriberOnPulse(157543293, subscriberDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_DeleteSubscriber_Pass()
        {
            try
            {
                _mondayClient.DeleteSubscriberOnPulse(157543293, 4939512).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_MovePulse_Pass()
        {
            var pulseMoveDto = new PulseMoveDto
            {
                GroupId = "incoming",
                PulseIds = "143344145, 143293324",
                UserId = 5412166,
                DestinationBoardId = 137870199,
                Force = false
            };

            try
            {
                _mondayClient.MovePulse(137870199, pulseMoveDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_DuplicatePulse_Pass()
        {
            var pulseDuplicateDto = new PulseDuplicateDto
            {
                GroupId = "incoming",
                UserId = 5412166
            };

            try
            {
                _mondayClient.DuplicatePulse(137870199, 143161227, pulseDuplicateDto).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Pulse_GetColumnValue_Pass()
        {
            var result = _mondayClient.GetPulseColumn(137872223, "status", 143703846).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Pulse_GetNoteList_Pass()
        {
            var result = _mondayClient.GetNotesByPulseId(143083605).Result;
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Pulse_CreateNote_Pass()
        {
            var noteDto = new NoteDto
            {
                UserId = 5412166,
                NoteTitle = "Unit Test Title",
                NoteText = "Unit Test Content Text",
                CreateUpdate = true,
                Locked = true
            };

            var result = _mondayClient.CreateNote(143083605, noteDto).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Pulse_UpdateNote_Pass()
        {
            var noteDto = new NoteDto
            {
                UserId = 5412166,
                NoteTitle = "Unit Test Title - Update",
                NoteText = "Unit Test Content Text - Update",
                CreateUpdate = true,
                Locked = true
            };

            var result = _mondayClient.UpdateNote(143083605, 6150364, noteDto).Result;
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void Pulse_DeleteNote_Pass()
        {
            try
            {
                _mondayClient.DeleteNote(143083605, 6150364).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public void Tag_GetTagById_Pass()
        {
            var result = _mondayClient.GetTagById(600593).Result;
            Assert.IsTrue(result != null);
        }

        /// <summary>
        /// Flawed yet debuggable
        /// </summary>
        [TestMethod]
        public void Tag_GetCachedTagById_Pass()
        {
            var result = _mondayClient.GetCachedTagById(600593).Result;
            Assert.IsTrue(result != null);

            var resultCached = _mondayClient.GetCachedTagById(600593).Result;
            Assert.IsTrue(resultCached != null);
        }
    }
}