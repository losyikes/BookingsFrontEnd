using Microsoft.JSInterop;

namespace PosBookingFrontEnd.Helpers
{
    public class SessionStorageAccessor : IAsyncDisposable
    {
        private Lazy<IJSObjectReference> accessorJsRef = new();
        private readonly IJSRuntime jsRuntime;

        public SessionStorageAccessor(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        private async Task WaitForReference()
        {
            if (accessorJsRef.IsValueCreated is false)
            {
                accessorJsRef = new(await jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/SessionStorageAccessor.js"));
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (accessorJsRef.IsValueCreated)
            {
                await accessorJsRef.Value.DisposeAsync();
            }
        }
        public async Task<T> GetValueAsync<T>(string key)
        {
            await WaitForReference();
            var result = await accessorJsRef.Value.InvokeAsync<T>("get", key);

            return result;
        }

        public async Task SetValueAsync<T>(string key, T value)
        {
            await WaitForReference();
            await accessorJsRef.Value.InvokeVoidAsync("set", key, value);
        }

        public async Task Clear()
        {
            await WaitForReference();
            await accessorJsRef.Value.InvokeVoidAsync("clear");
        }

        public async Task RemoveAsync(string key)
        {
            await WaitForReference();
            await accessorJsRef.Value.InvokeVoidAsync("remove", key);
        }
    }
}
