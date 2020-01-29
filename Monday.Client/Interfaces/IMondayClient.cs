using Monday.Client.Dtos;
using Monday.Client.Models;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monday.Client.Interfaces
{
    public interface IMondayClient
    {
        [Path("apiKey")] string ApiKey { get; set; }

        [Get("users.json?api_key={apiKey}")]
        Task<List<User>> GetUsersAsync([Query("per_page")] int returnCount);

        [Get("users/{userId}.json?api_key={apiKey}")]
        Task<User> GetUserByIdAsync([Path] int userId);

        [Get("users/{userId}/posts.json?api_key={apiKey}")]
        Task<List<Update>> GetPostsByUserIdAsync([Path] int userId, [Query("per_page")] int returnCount);

        [Get("users/{userId}/newsfeed.json?api_key={apiKey}")]
        Task<List<Update>> GetNewsfeedByUserIdAsync([Path] int userId, [Query("per_page")] int returnCount, [Query("page")] int returnIndex);

        [Get("users/{userId}/unread_feed.json?api_key={apiKey}")]
        Task<List<Update>> GetUnreadNewsfeedByUserIdAsync([Path] int userId, [Query("per_page")] int returnCount, [Query("page")] int returnIndex);

        [Get("boards.json?api_key={apiKey}")]
        Task<List<Board>> GetBoardsAsync([Query("per_page")] int returnCount);

        [Get("boards/{boardId}.json?api_key={apiKey}")]
        Task<Board> GetBoardByIdAsync([Path] int boardId);

        [Post("boards.json?api_key={apiKey}")]
        Task<Board> PostBoardAsync([Body] BoardDto boardDto);

        [Delete("boards/{boardId}.json?api_key={apiKey}")]
        Task DeleteBoardByIdAsync([Path] int boardId);

        [Put("boards/{boardId}/groups.json?api_key={apiKey}")]
        Task PutGroupByBoardIdAsync([Path] int boardId, [Body] GroupDto groupDto);

        [Post("boards/{boardId}/groups.json?api_key={apiKey}")]
        Task PostGroupByBoardIdAsync([Path] int boardId, [Body] GroupDto groupDto);

        [Post("boards/{boardId}/groups/{groupId}/move.json?api_key={apiKey}")]
        Task PostMoveGroupByBoardIdAndGroupIdAsync([Path] int boardId, [Path] string groupId, [Body] GroupMoveDto groupDto);

        [Delete("boards/{boardId}/groups/{groupId}.json?api_key={apiKey}")]
        Task DeleteGroupByBoardIdAndGroupIdAsync([Path] int boardId, [Path] string groupId);

        [Post("boards/{boardId}/pulses.json?api_key={apiKey}")]
        Task<BoardPulse> PostPulseByBoardIdAsync([Path] int boardId, [Body] PulseDto pulseDto);

        [Post("boards/{boardId}/pulses/{pulseId}/duplicate.json?api_key={apiKey}")]
        Task<BoardPulse> PostDuplicatePulseByBoardIdAndPulseIdAsync([Path] int boardId, [Path] int pulseId, [Body] PulseDuplicateDto pulseDuplicateDto);

        [Post("boards/{boardId}/pulses/move.json?api_key={apiKey}")]
        Task<BoardPulse> PostMovePulseByBoardIdAndParamsAsync([Path] int boardId, [Body] PulseMoveDto pulseMoveDto);

        [Put("boards/{boardId}/columns/{columnId}/text.json?api_key={apiKey}")]
        Task PutBoardColumnTextByBoardIdAndParamsAsync([Path] int boardId, [Path] string columnId, [Body] BoardColumnTextDto columnDto);

        [Put("boards/{boardId}/columns/{columnId}/person.json?api_key={apiKey}")]
        Task PutBoardColumnPersonByBoardIdAndParamsAsync([Path] int boardId, [Path] string columnId, [Body] BoardColumnPersonDto columnDto);

        [Put("boards/{boardId}/columns/{columnId}/status.json?api_key={apiKey}")]
        Task PutBoardColumnStatusByBoardIdAndParamsAsync([Path] int boardId, [Path] string columnId, [Body] BoardColumnStatusDto columnDto);

        [Put("boards/{boardId}/columns/{columnId}/date.json?api_key={apiKey}")]
        Task PutBoardColumnDateByBoardIdAndParamsAsync([Path] int boardId, [Path] string columnId, [Body] BoardColumnDateDto columnDto);

        [Put("boards/{boardId}/columns/{columnId}/numeric.json?api_key={apiKey}")]
        Task PutBoardColumnNumericByBoardIdAndParamsAsync([Path] int boardId, [Path] string columnId, [Body] BoardColumnNumericDto columnDto);

        [Put("boards/{boardId}/columns/{columnId}/tags.json?api_key={apiKey}")]
        Task PutBoardColumnTagByBoardIdAndParamsAsync([Path] int boardId, [Path] string columnId, [Body] BoardColumnTagDto columnDto);

        [Put("boards/{boardId}/columns/{columnId}/timeline.json?api_key={apiKey}")]
        Task PutBoardColumnTimelineByBoardIdAndParamsAsync([Path] int boardId, [Path] string columnId, [Body] BoardColumnTimelineDto columnDto);

        [Get("boards/{boardId}/columns/{columnId}/value.json?api_key={apiKey}")]
        Task<object> GetPulseColumnByBoardIdAndColumnIdAndPulseIdAsync([Path] int boardId, [Path] string columnId, [Query("pulse_id")] int pulseId);

        [Get("boards/{boardId}/pulses.json?api_key={apiKey}&per_page=25")]
        Task<List<BoardPulse>> GetPulsesbyBoardIdAsync([Path] int boardId, [Query("page")] int returnIndex);

        [Get("pulses.json?api_key={apiKey}")]
        Task<List<Pulse>> GetPulsesAsync([Query("per_page")] int returnCount, [Query("since")] string inDate, [Query("until")] string outDate);

        [Get("pulses/{pulseId}.json?api_key={apiKey}")]
        Task<Pulse> GetPulseByIdAsync([Path] int pulseId);

        [Get("updates.json?api_key={apiKey}")]
        Task<List<Update>> GetUpdatesAsync([Query("per_page")] int returnCount, [Query("since")] string inDate, [Query("until")] string outDate);

        [Get("pulses/{pulseId}/updates.json?api_key={apiKey}")]
        Task<List<Update>> GetUpdatesByPulseIdAsync([Path] int pulseId);

        [Post("updates/{updateId}/like.json?api_key={apiKey}")]
        Task PostLikeUpdateByUpdateIdAsync([Path] int updateId, [Body] UpdateLikeDto updateLikeDto);

        [Post("updates/{updateId}/unlike.json?api_key={apiKey}")]
        Task PostUnLikeUpdateByUpdateIdAsync([Path] int updateId, [Body] UpdateLikeDto updateLikeDto);

        [Put("pulses/{pulseId}.json?api_key={apiKey}")]
        Task<Pulse> PutPulseByIdAsync([Path] int pulseId, [Body] PulseDto.PulseProperties pulseDto);

        [Delete("pulses/{pulseId}.json?api_key={apiKey}&archive=true")]
        Task DeletePulseByIdAsync([Path] int pulseId);

        [Post("updates.json?api_key={apiKey}")]
        Task PostUpdateByUserIdAndPulseIdAsync([Body] UpdateDto updateDto);

        [Delete("updates/{updateId}.json?api_key={apiKey}")]
        Task DeleteUpdateByIdAsync([Path] int updateId);

        [Get("pulses/{pulseId}/notes.json?api_key={apiKey}")]
        Task<List<Note>> GetNotesByPulseIdAsync([Path] int pulseId);

        [Post("pulses/{pulseId}/notes.json?api_key={apiKey}")]
        Task<Note> PostNoteByPulseIdAsync([Path] int pulseId, [Body] NoteDto noteDto);

        [Put("pulses/{pulseId}/notes/{noteId}.json?api_key={apiKey}")]
        Task<Note> PutNoteByPulseIdAndNoteIdAsync([Path] int pulseId, [Path] int noteId, [Body] NoteDto noteDto);

        [Delete("pulses/{pulseId}/notes/{noteId}.json?api_key={apiKey}")]
        Task DeleteNoteByPulseIdAndNoteIdAsync([Path] int pulseId, [Path] int noteId);

        [Get("pulses/{pulseId}/subscribers.json?api_key={apiKey}")]
        Task<List<User>> GetSubscribersByPulseIdAsync([Path] int pulseId);

        [Put("pulses/{pulseId}/subscribers.json?api_key={apiKey}")]
        Task<User> PutSubscriberByPulseIdAndUserIdAsync([Path] int pulseId, [Body] SubscriberDto subscriberDto);

        [Delete("pulses/{pulseId}/subscribers/{userId}.json?api_key={apiKey}")]
        Task DeleteSubscriberByPulseIdAndUserIdAsync([Path] int pulseId, [Path] int userId);

        [Get("boards/{boardId}/subscribers.json?api_key={apiKey}")]
        Task<List<User>> GetSubscribersByBoardIdAsync([Path] int boardId);

        [Put("boards/{boardId}/subscribers.json?api_key={apiKey}")]
        Task<User> PutSubscriberByBoardIdAndUserIdAsync([Path] int boardId, [Body] SubscriberDto subscriberDto);

        [Delete("boards/{boardId}/subscribers/{userId}.json?api_key={apiKey}")]
        Task DeleteSubscriberByBoardIdAndUserIdAsync([Path] int boardId, [Path] int userId);

        [Get("tags/{tagId}.json?api_key={apiKey}")]
        Task<Tag> GetTagByIdAsync([Path] int tagId);
    }
}