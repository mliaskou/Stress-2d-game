using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class AddressablesLoader
{
    public static IEnumerator LoadAddressablesAsync(string addressablesKey,
    Action<AsyncOperationHandle> gameObjectAsyncOperationHandle)
    {
        AsyncOperationHandle opHandle = Addressables.LoadAssetAsync<GameObject>(addressablesKey);
        yield return opHandle;

        if (opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            gameObjectAsyncOperationHandle?.Invoke(opHandle);
        }
    }

    public static IEnumerator LoadAddressablesAsync<T>(string addressablesKey,
    Action<AsyncOperationHandle> gameObjectAsyncOperationHandle) where T:class
    {
        AsyncOperationHandle opHandle = Addressables.LoadAssetAsync<T>(addressablesKey);
        yield return opHandle;

        if (opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            gameObjectAsyncOperationHandle?.Invoke(opHandle);
        }
    }

    public static void ReleaseAddressableHandle(AsyncOperationHandle asyncOperationHandle)
    {
        if (asyncOperationHandle.IsValid())
        {
            Addressables.Release(asyncOperationHandle);
        }
    }
}
