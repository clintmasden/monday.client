using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Monday.Client.Dtos;
using Monday.Client.Extensions;
using Monday.Client.Interfaces;
using Monday.Client.Models;
using RestEase;

namespace Monday.Client
{
    /// <summary>
    ///     Creates client for accessing monday's api's.
    /// </summary>
    public class MondayClient
    {
        private readonly HashSet<Tag> _tagCachedList = new HashSet<Tag>();

        /// <summary>
        ///     Creates client for accessing monday's api's.
        /// </summary>
        /// <param name="apiKey">the api key for accessing information.</param>
        public MondayClient(string apiKey)
        {
            // For VS15 -  System.AggregateException' in mscorlib.dll
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Setting up date range
            var inDate = DateTime.Now.GetStartOfWeek(DayOfWeek.Monday);
            _inDate = inDate.ToString(@"yyyy-MM-dd");
            _outDate = inDate.AddDays(5).ToString(@"yyyy-MM-dd");

            // Setting up Interface
            _mondayClient = RestClient.For<IMondayClient>("https://api.monday.com:443/v1/");
            _mondayClient.ApiKey = apiKey;
        }

        private string _inDate { get; }
        private string _outDate { get; }

        private IMondayClient _mondayClient { get; }

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <param name="returnCount">Number of results to return per page.</param>
        /// <returns></returns>
        public async Task<List<User>> GetUsers(int returnCount = 200)
        {
            var result = await _mondayClient.GetUsersAsync(returnCount);

            result = result.OrderBy(c => c.Name).ToList();

            return result;
        }

        /// <summary>
        ///     Return a specific user.
        /// </summary>
        /// <param name="userId">The requested user’s unique identifier.</param>
        /// <returns></returns>
        public async Task<User> GetUserById(int userId)
        {
            return await _mondayClient.GetUserByIdAsync(userId);
        }

        /// <summary>
        ///     Return a specific user's posts.
        /// </summary>
        /// <param name="userId">The requested user’s unique identifier.</param>
        /// <param name="returnCount">Number of results to return per page.</param>
        /// <returns></returns>
        public async Task<List<Update>> GetUserPosts(int userId, int returnCount = 50)
        {
            return await _mondayClient.GetPostsByUserIdAsync(userId, returnCount);
        }

        /// <summary>
        ///     Return the newsfeed of a specific user.
        /// </summary>
        /// <param name="userId">The requested user’s unique identifier.</param>
        /// <param name="returnCount">Number of results to return per page.</param>
        /// <param name="returnIndex">Page offset to fetch.</param>
        /// <returns></returns>
        public async Task<List<Update>> GetUserNewsfeed(int userId, int returnCount = 50, int returnIndex = 1)
        {
            return await _mondayClient.GetNewsfeedByUserIdAsync(userId, returnCount, returnIndex);
        }

        /// <summary>
        ///     Return the unread newsfeed of a specific user.
        /// </summary>
        /// <param name="userId">The requested user’s unique identifier.</param>
        /// <param name="returnCount">Number of results to return per page.</param>
        /// <param name="returnIndex">Page offset to fetch.</param>
        /// <returns></returns>
        public async Task<List<Update>> GetUserUnreadNewsfeed(int userId, int returnCount = 50, int returnIndex = 1)
        {
            return await _mondayClient.GetUnreadNewsfeedByUserIdAsync(userId, returnCount, returnIndex);
        }

        /// <summary>
        ///     Get all the account's boards.
        /// </summary>
        /// <param name="returnCount">Number of results.</param>
        /// <returns></returns>
        public async Task<List<Board>> GetBoards(int returnCount = 100)
        {
            var result = await _mondayClient.GetBoardsAsync(returnCount);

            result = result.OrderBy(c => c.Name).ToList();

            return result;
        }

        /// <summary>
        ///     Returns a specific board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task<Board> GetBoardById(int boardId)
        {
            return await _mondayClient.GetBoardByIdAsync(boardId);
        }

        /// <summary>
        ///     Creates a new board.
        /// </summary>
        /// <param name="boardDto">
        ///     {UserId: Required [The board’s owner.], Name: Required [The board’s name.], Description:
        ///     Optional, BoardKind: Optional [Enumeration] }
        /// </param>
        /// <returns></returns>
        public async Task<Board> CreateBoard(BoardDto boardDto)
        {
            return await _mondayClient.PostBoardAsync(boardDto);
        }

        /// <summary>
        ///     Archives a specific board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task DeleteBoard(int boardId)
        {
            await _mondayClient.DeleteBoardByIdAsync(boardId);
        }

        /// <summary>
        ///     Update a text column's value
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="columnId">The column’s unique identifier.</param>
        /// <param name="columnDto">{PulseId: Required, Text: Required [A text column’s value.]}</param>
        /// <returns></returns>
        public async Task UpdateBoardTextColumn(int boardId, string columnId, BoardColumnTextDto columnDto)
        {
            await _mondayClient.PutBoardColumnTextByBoardIdAndParamsAsync(boardId, columnId, columnDto);
        }

        /// <summary>
        ///     Update a person column's value
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="columnId">The column’s unique identifier.</param>
        /// <param name="columnDto">{PulseId: Required, UserId: Required}</param>
        /// <returns></returns>
        public async Task UpdateBoardPersonColumn(int boardId, string columnId, BoardColumnPersonDto columnDto)
        {
            await _mondayClient.PutBoardColumnPersonByBoardIdAndParamsAsync(boardId, columnId, columnDto);
        }

        /// <summary>
        ///     Update a status column's value
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="columnId">The column’s unique identifier.</param>
        /// <param name="columnDto">{PulseId: Required, ColorId: Required [A status column’s color index (must be a 0-19 value).]}</param>
        /// <returns></returns>
        public async Task UpdateBoardStatusColumn(int boardId, string columnId, BoardColumnStatusDto columnDto)
        {
            await _mondayClient.PutBoardColumnStatusByBoardIdAndParamsAsync(boardId, columnId, columnDto);
        }

        /// <summary>
        ///     Update a date column's value
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="columnId">The column’s unique identifier.</param>
        /// <param name="columnDto">
        ///     {PulseId: Required, Date: Required [A due date column’s value in a yyyy-MM-dd format (example:
        ///     ‘2014-05-15’).]}
        /// </param>
        /// <returns></returns>
        public async Task UpdateBoardDateColumn(int boardId, string columnId, BoardColumnDateDto columnDto)
        {
            await _mondayClient.PutBoardColumnDateByBoardIdAndParamsAsync(boardId, columnId, columnDto);
        }

        /// <summary>
        ///     Update a numeric column's value
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="columnId">The column’s unique identifier.</param>
        /// <param name="columnDto">{PulseId: Required, Value: Required [A numbers column’s value]}</param>
        /// <returns></returns>
        public async Task UpdateBoardNumericColumn(int boardId, string columnId, BoardColumnNumericDto columnDto)
        {
            await _mondayClient.PutBoardColumnNumericByBoardIdAndParamsAsync(boardId, columnId, columnDto);
        }

        /// <summary>
        ///     Update a tag column's value
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="columnId">The column’s unique identifier.</param>
        /// <param name="columnDto">
        ///     {PulseId: Required, Tags: Required [A string of tags with a ‘,’ seperator for multiple tags for
        ///     example: tag1, tag2, tag3]}
        /// </param>
        /// <returns></returns>
        public async Task UpdateBoardTagColumn(int boardId, string columnId, BoardColumnTagDto columnDto)
        {
            await _mondayClient.PutBoardColumnTagByBoardIdAndParamsAsync(boardId, columnId, columnDto);
        }

        /// <summary>
        ///     Update a tag column's value
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="columnId">The column’s unique identifier.</param>
        /// <param name="columnDto">
        ///     {PulseId: Required, InDate: Required [A timeline column’s start date in a yyyy-MM-dd format
        ///     (example: ‘2016-12-15’)..], OutDate: Required [A timeline column’s end date in a yyyy-MM-dd format (example:
        ///     ‘2016-12-16’)..]}
        /// </param>
        /// <returns></returns>
        public async Task UpdateBoardTimelineColumn(int boardId, string columnId, BoardColumnTimelineDto columnDto)
        {
            await _mondayClient.PutBoardColumnTimelineByBoardIdAndParamsAsync(boardId, columnId, columnDto);
        }

        /// <summary>
        ///     Get a column value for a given Pulse.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="columnId">The column’s unique identifier.</param>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <returns></returns>
        public async Task<dynamic> GetPulseColumn(int boardId, string columnId, int pulseId)
        {
            return await _mondayClient.GetPulseColumnByBoardIdAndColumnIdAndPulseIdAsync(boardId, columnId, pulseId);
        }

        /// <summary>
        ///     Create a new group in the board.
        /// </summary>
        /// <param name="boardId">A board’s unique identifier.</param>
        /// <param name="groupDto">{GroupId: NA, Title: Required, Color: NA}</param>
        /// <returns></returns>
        public async Task CreateGroup(int boardId, GroupDto groupDto)
        {
            await _mondayClient.PostGroupByBoardIdAsync(boardId, groupDto);
        }

        /// <summary>
        ///     Update group's attributes.
        /// </summary>
        /// <param name="boardId">A board’s unique identifier.</param>
        /// <param name="groupDto">
        ///     {GroupId: Required, Title: Required, Color: Optional [037f4c - dark green, fdab3d - orange,
        ///     579bfc - blue, e2445c - red, 00c875 - green, c4c4c4 - grey, 0086c0 - dark blue, a25ddc - purple, ffcb00 - yellow,
        ///     333333 - black]}
        /// </param>
        /// <returns></returns>
        public async Task UpdateGroup(int boardId, GroupDto groupDto)
        {
            await _mondayClient.PutGroupByBoardIdAsync(boardId, groupDto);
        }

        /// <summary>
        ///     Archive a specific group.
        /// </summary>
        /// <param name="boardId">A board’s unique identifier.</param>
        /// <param name="groupId">A group’s unique identifier.</param>
        /// <returns></returns>
        public async Task DeleteGroup(int boardId, string groupId)
        {
            await _mondayClient.DeleteGroupByBoardIdAndGroupIdAsync(boardId, groupId);
        }

        /// <summary>
        ///     Move group to another board.
        /// </summary>
        /// <param name="boardId">A board’s unique identifier.</param>
        /// <param name="groupId">A group’s unique identifier.</param>
        /// <param name="groupMoveDto">{UserId: Required, DestinationBoardId: Required}</param>
        /// <returns></returns>
        public async Task MoveGroup(int boardId, string groupId, GroupMoveDto groupMoveDto)
        {
            await _mondayClient.PostMoveGroupByBoardIdAndGroupIdAsync(boardId, groupId, groupMoveDto);
        }

        /// <summary>
        ///     Returns the board's pulses
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task<List<BoardPulse>> GetPulsesByBoardId(int boardId)
        {
            // monday limits only 25 pulses per api call (those smart shits)
            var pulseIndex = 1;
            var pulseList = new List<BoardPulse>();

            var result = await _mondayClient.GetPulsesbyBoardIdAsync(boardId, pulseIndex);

            do
            {
                pulseList.AddRange(result);

                pulseIndex++;
                result = await _mondayClient.GetPulsesbyBoardIdAsync(boardId, pulseIndex);
            }
            while (result != null && result.Count > 0);

            pulseList = pulseList.OrderBy(c => c.Pulse.CreatedAt).ToList();

            return pulseList;
        }

        /// <summary>
        ///     Get all the account's pulses.
        /// </summary>
        /// <param name="returnCount">Number of results to return per page.</param>
        /// <param name="inDate">Get pulses from a certain date. [Default: Monday] (Since, Start Date)</param>
        /// <param name="outDate">Get pulses until a certain date. [Default: Friday] (Until, End Date)</param>
        /// <returns></returns>
        public async Task<List<Pulse>> GetPulses(int returnCount = 100, DateTime? inDate = null, DateTime? outDate = null)
        {
            // week date range
            var mInDate = _inDate;
            var mOutDate = _outDate;

            // Setting up user date range
            if (inDate.HasValue)
            {
                mInDate = inDate.Value.ToString(@"yyyy-MM-dd");
            }

            if (outDate.HasValue)
            {
                mOutDate = outDate.Value.ToString(@"yyyy-MM-dd");
            }

            var result = await _mondayClient.GetPulsesAsync(returnCount, mInDate, mOutDate);

            result = result.OrderBy(c => c.CreatedAt).ToList();

            return result;
        }

        /// <summary>
        ///     Returns a specific pulse.
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <returns></returns>
        public async Task<Pulse> GetPulseById(int pulseId)
        {
            return await _mondayClient.GetPulseByIdAsync(pulseId);
        }

        /// <summary>
        ///     Create a new pulse in a board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="pulseDto">
        ///     {UserId: Required, PulseName: Required, PhotoUrl: Optional [A URL to fetch the new pulse’s
        ///     picture from.], Text: Optional [The update’s text (can contain simple HTML tags for formatting the text).],
        ///     GroupId: Optional, AddToBottom: Optional }
        /// </param>
        /// <returns></returns>
        public async Task<BoardPulse> CreatePulse(int boardId, PulseDto pulseDto)
        {
            return await _mondayClient.PostPulseByBoardIdAsync(boardId, pulseDto);
        }

        /// <summary>
        ///     Update Pulse's attributes.
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <param name="pulseDto">{PulseId: Required,  Name: Required}</param>
        /// <returns></returns>
        public async Task<Pulse> UpdatePulse(int pulseId, PulseDto.PulseProperties pulseDto)
        {
            return await _mondayClient.PutPulseByIdAsync(pulseId, pulseDto);
        }

        /// <summary>
        ///     Deletes a specific pulse. [Archives by default]
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <returns></returns>
        public async Task DeletePulse(int pulseId)
        {
            await _mondayClient.DeletePulseByIdAsync(pulseId);
        }

        /// <summary>
        ///     Move pulses to another group/board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="pulseDto">
        ///     {UserId: Required [The user performing the action unique identifier.], GroupId: Required [The
        ///     destination group’s unique identifier.], PulseIds: Required [A string of pulses ids with a ‘,’ seperator for
        ///     multiple pulses ids (max 100) for example: id1,id2,id3], DestinationBoardId: Required [The destination board’s
        ///     unique identifier. Default is original board.], Force: Optional [Move to destination board even if some columns do
        ///     not exist in the destination board. Default is false.]}
        /// </param>
        /// <returns></returns>
        public async Task MovePulse(int boardId, PulseMoveDto pulseDto)
        {
            await _mondayClient.PostMovePulseByBoardIdAndParamsAsync(boardId, pulseDto);
        }

        /// <summary>
        ///     Duplicate pulse to another group/board
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <param name="pulseDto">
        ///     {GroupId: Optional, OwnerId: Optional [The user who will own the new pulse. If non given
        ///     chooses the board’s owner.]}
        /// </param>
        /// <returns></returns>
        public async Task DuplicatePulse(int boardId, int pulseId, PulseDuplicateDto pulseDto)
        {
            await _mondayClient.PostDuplicatePulseByBoardIdAndPulseIdAsync(boardId, pulseId, pulseDto);
        }

        /// <summary>
        ///     Creates a new note.
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <param name="noteDto">
        ///     {UserId: Required, Title: Required, NoteText: Required, Locked: Optional [Only pulse owners can
        ///     edit this note.], CreateUpdate: Optional [Indicates wether to create an update on the pulse notifiying subscribers
        ///     on the changes.]
        /// </param>
        /// <returns></returns>
        public async Task<Note> CreateNote(int pulseId, NoteDto noteDto)
        {
            return await _mondayClient.PostNoteByPulseIdAsync(pulseId, noteDto);
        }

        /// <summary>
        ///     Update Note's attributes
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <param name="noteId">The note's unique identifier</param>
        /// <param name="noteDto">
        ///     {UserId: Required, Title: Optional, NoteText: Optional, Locked: Optional [Only pulse owners can
        ///     edit this note.], CreateUpdate: Optional [Indicates wether to create an update on the pulse notifiying subscribers
        ///     on the changes.]
        /// </param>
        /// <returns></returns>
        public async Task<Note> UpdateNote(int pulseId, int noteId, NoteDto noteDto)
        {
            return await _mondayClient.PutNoteByPulseIdAndNoteIdAsync(pulseId, noteId, noteDto);
        }

        /// <summary>
        ///     Deletes a specific note.
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <param name="noteId">The note's unique identifier</param>
        /// <returns></returns>
        public async Task DeleteNote(int pulseId, int noteId)
        {
            await _mondayClient.DeleteNoteByPulseIdAndNoteIdAsync(pulseId, noteId);
        }

        /// <summary>
        ///     Get all the account's updates.
        /// </summary>
        /// <param name="returnCount">Number of results to return per page.</param>
        /// <param name="inDate">Get updates from a certain date. [Default: Monday] (Since, Start Date)</param>
        /// <param name="outDate">Get updates until a certain date. [Default: Friday] (Until, End Date)</param>
        /// <returns></returns>
        public async Task<List<Update>> GetUpdates(int returnCount = 100, DateTime? inDate = null, DateTime? outDate = null)
        {
            // week date range
            var mInDate = _inDate;
            var mOutDate = _outDate;

            // Setting up user date range
            if (inDate.HasValue)
            {
                mInDate = inDate.Value.ToString(@"yyyy-MM-dd");
            }

            if (outDate.HasValue)
            {
                mOutDate = outDate.Value.ToString(@"yyyy-MM-dd");
            }

            var result = await _mondayClient.GetUpdatesAsync(returnCount, mInDate, mOutDate);

            result = result.OrderBy(c => c.CreatedAt).ToList();

            return result;
        }

        /// <summary>
        ///     Creates a new update on a pulse.
        /// </summary>
        /// <param name="updateDto">
        ///     {UserId: Required, PulseId: Required, Text: Required [The update’s text (can contain simple
        ///     HTML tags for formatting the text).]}
        /// </param>
        /// <returns></returns>
        public async Task CreateUpdate(UpdateDto updateDto)
        {
            await _mondayClient.PostUpdateByUserIdAndPulseIdAsync(updateDto);
        }

        /// <summary>
        ///     Deletes an update.
        /// </summary>
        /// <param name="updateId">The updates’s unique identifier.</param>
        /// <returns></returns>
        public async Task DeleteUpdate(int updateId)
        {
            await _mondayClient.DeleteUpdateByIdAsync(updateId);
        }

        /// <summary>
        ///     Like an update.
        /// </summary>
        /// <param name="updateId">The updates’s unique identifier.</param>
        /// <param name="updateLikeDto">The dto for user’s unique identifier.</param>
        /// <returns></returns>
        public async Task CreateLikeOnPulseUpdate(int updateId, UpdateLikeDto updateLikeDto)
        {
            await _mondayClient.PostLikeUpdateByUpdateIdAsync(updateId, updateLikeDto);
        }

        /// <summary>
        ///     UnLike an update.
        /// </summary>
        /// <param name="updateId">The updates’s unique identifier.</param>
        /// <param name="updateLikeDto">The dto for user’s unique identifier.</param>
        /// <returns></returns>
        public async Task CreateUnLikeOnPulseUpdate(int updateId, UpdateLikeDto updateLikeDto)
        {
            await _mondayClient.PostUnLikeUpdateByUpdateIdAsync(updateId, updateLikeDto);
        }

        /// <summary>
        ///     Gets the pulse's updates wall.
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <returns></returns>
        public async Task<List<Update>> GetUpdatesByPulseId(int pulseId)
        {
            var result = await _mondayClient.GetUpdatesByPulseIdAsync(pulseId);

            result = result.OrderByDescending(c => c.CreatedAt).ToList();

            return result;
        }

        /// <summary>
        ///     Gets a list of notes attached to the pulse.
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <returns></returns>
        public async Task<List<Note>> GetNotesByPulseId(int pulseId)
        {
            var result = await _mondayClient.GetNotesByPulseIdAsync(pulseId);

            result = result.OrderByDescending(c => c.CreatedAt).ToList();

            return result;
        }

        /// <summary>
        ///     Returns the pulse's subscribers
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <returns></returns>
        public async Task<List<User>> GetSubscribersByPulseIdAsync(int pulseId)
        {
            return await _mondayClient.GetSubscribersByPulseIdAsync(pulseId);
        }

        /// <summary>
        ///     Add a subscriber to the pulse.
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <param name="subscriberDto">The requested user’s unique identifier.</param>
        /// <returns></returns>
        public async Task<User> CreateSubscriberOnPulse(int pulseId, SubscriberDto subscriberDto)
        {
            return await _mondayClient.PutSubscriberByPulseIdAndUserIdAsync(pulseId, subscriberDto);
        }

        /// <summary>
        ///     Remove a subscriber from the pulse.
        /// </summary>
        /// <param name="pulseId">The pulse’s unique identifier.</param>
        /// <param name="userId">The requested user’s unique identifier.</param>
        /// <returns></returns>
        public async Task DeleteSubscriberOnPulse(int pulseId, int userId)
        {
            await _mondayClient.DeleteSubscriberByPulseIdAndUserIdAsync(pulseId, userId);
        }

        /// <summary>
        ///     Returns the boards's subscribers
        /// </summary>
        /// <param name="boardId">The boards’s unique identifier.</param>
        /// <returns></returns>
        public async Task<List<User>> GetSubscribersByBoardIdAsync(int boardId)
        {
            return await _mondayClient.GetSubscribersByBoardIdAsync(boardId);
        }

        /// <summary>
        ///     Add a subscriber to the board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="subscriberDto">The requested user’s unique identifier.</param>
        /// <returns></returns>
        public async Task<User> CreateSubscriberOnBoard(int boardId, SubscriberDto subscriberDto)
        {
            return await _mondayClient.PutSubscriberByBoardIdAndUserIdAsync(boardId, subscriberDto);
        }

        /// <summary>
        ///     Remove a subscriber from the board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="userId">The requested user’s unique identifier.</param>
        /// <returns></returns>
        public async Task DeleteSubscriberOnBoard(int boardId, int userId)
        {
            await _mondayClient.DeleteSubscriberByPulseIdAndUserIdAsync(boardId, userId);
        }

        /// <summary>
        ///     Returns a specific tag.
        /// </summary>
        /// <param name="tagId">The tag’s unique identifier.</param>
        /// <returns></returns>
        public async Task<Tag> GetTagById(int tagId)
        {
            var result = await _mondayClient.GetTagByIdAsync(tagId);

            _tagCachedList.Add(result);

            return result;
        }

        /// <summary>
        ///     Returns a specific tag and caches for reuse.
        /// </summary>
        /// <param name="tagId">The tag’s unique identifier.</param>
        /// <returns></returns>
        public async Task<Tag> GetCachedTagById(int tagId)
        {
            var tagCached = _tagCachedList.SingleOrDefault(c => c.Id == tagId);

            if (tagCached != null)
            {
                return tagCached;
            }

            var result = await _mondayClient.GetTagByIdAsync(tagId);

            _tagCachedList.Add(result);

            return result;
        }
    }
}