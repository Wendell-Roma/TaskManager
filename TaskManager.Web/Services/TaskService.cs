using System.Net.Http.Json;
using TaskManager.Web.Models;

namespace TaskManager.Web.Services;

public class TaskService
{
    private readonly HttpClient _http;

    public TaskService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TaskModel>> GetTasksAsync()
    {
        var result = await _http.GetFromJsonAsync<List<TaskModel>>("api/Tasks");
        return result ?? new List<TaskModel>();
    }

    public async Task<bool> CreateTaskAsync(TaskRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/Tasks", request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateTaskAsync(int id, TaskRequest request)
    {
        var response = await _http.PutAsJsonAsync($"api/Tasks/{id}", request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/Tasks/{id}");
        return response.IsSuccessStatusCode;
    }
}