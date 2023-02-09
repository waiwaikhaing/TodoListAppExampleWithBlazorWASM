using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.Security.Cryptography.X509Certificates;
using TodoListAppExampleWithBlazorWASM.Models;

namespace TodoListAppExampleWithBlazorWASM.Pages
{
    public partial class Index
    {
        [Inject]
        public IDialogService DialogService { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Parameter]
        public string todoitem { get; set; }
        public List<TodoItemModel> lst { get; set; } = new List<TodoItemModel>();
        public TodoItemModel model = new TodoItemModel();
        private DotNetObjectReference<Index>? objRef;
        protected override async Task OnInitializedAsync()
        {
            objRef = DotNetObjectReference.Create(this);
        }
        async Task Save()
        {
            if (model.Item == null)
            {
                await JSRuntime.InvokeVoidAsync("showAlert", "Please Enter a Task");
            }
            else
            {
                if (lst != null && lst.Count > 0 && model.Item != null)
                {
                    lst.Add(new TodoItemModel { Item = model.Item });
                }
                else lst.Add(new TodoItemModel { Item = model.Item });
                model.Item = string.Empty;
            }
        }

        async Task Delete(string item)
        {

            if (lst.Count > 0 && item != null)
            {
                model.Item = item;
                lst.RemoveAt(lst.ToList<TodoItemModel>().FindIndex(e => e.Item == model.Item));
            }
        }

        async Task ToggleText(string item)
        {
            if (lst.Count > 0 && item != null)
            {
                 await JSRuntime.InvokeVoidAsync("ToggleText", item);
            }
        }
    }
}
