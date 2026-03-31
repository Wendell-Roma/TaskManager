using TaskManager.Core.Entities;

namespace TaskManager.Core.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllByUserIdAsync(int userId);
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> CreateAsync(TaskItem task);
    Task<TaskItem> UpdateAsync(TaskItem task);
    Task DeleteAsync(int id);
}