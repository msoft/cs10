using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS10_Tests
{

    [AsyncMethodBuilder(typeof(CustomAwaitableAsyncMethodBuilder    ))]
    public class CustomAwaitable
    {
        private readonly Task task;
        public bool HasBeenExecuted { get; private set; }
        public Exception Exception { get; private set; }

        public CustomAwaitable()
        {
            this.task = new Task(() => {
                Console.WriteLine("Executed");
            });
            this.Exception = null;
        }

        public TaskAwaiter GetAwaiter() => task.GetAwaiter();

        internal bool TrySetResult()
        {
            //if (status != FiberStatus.Pending) return false;
            //else
            //{
            //    status = FiberStatus.Success;
            //    this.result = result;
            //    this.continuation?.Invoke();
            //    return true;
            //}

            this.HasBeenExecuted = true;
            return true;
        }

        internal bool TrySetException(Exception exception)
        {
            //if (status != FiberStatus.Pending) return false;
            //else
            //{
            //    status = FiberStatus.Failed;
            //    this.Exception = exception;
            //    this.continuation?.Invoke();
            //    return true;
            //}
            this.Exception = exception;
            return true;
        }
    }



    public class CustomAwaitableAsyncMethodBuilder
    //     ^^^^^^ Only works if you change this to `class` or run in Debug mode
    {
        #region fields


        private CustomAwaitable customAwaitable;

        //Exception? _exception;
        //bool _hasResult;
        //SpinLock _lock;
        //T? _result;
        //TaskCompletionSource? _source;

        #endregion

        #region properties

        public CustomAwaitable Task
        {
            get
            {
                //var lockTaken = false;
                //try
                //{
                //    _lock.Enter(ref lockTaken);
                //    if (_exception is not null)
                //        return new CustomAwaitable(Task.FromException(_exception));
                //    if (_hasResult)
                //        return new CustomAwaitable(ValueTask.FromResult(_result!));
                //    return new CustomAwaitable(
                //        new ValueTask(
                //            (_source ??= new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously))
                //            .Task
                //        )
                //    );
                //}
                //finally
                //{
                //    if (lockTaken)
                //        _lock.Exit();
                //}

                return this.customAwaitable ??= new CustomAwaitable();
            }
        }

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter,
            ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine =>
            awaiter.OnCompleted(stateMachine.MoveNext);

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter,
            ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine =>
            awaiter.UnsafeOnCompleted(stateMachine.MoveNext);

        #endregion

        #region methods

        public static CustomAwaitableAsyncMethodBuilder Create() => new()
        {
            //_lock = new SpinLock(Debugger.IsAttached)
        };

        public void SetException(Exception e) => Task.TrySetException(e);

        public void SetResult() => Task.TrySetResult();

        //public void SetException(Exception exception)
        //{
        //    var lockTaken = false;
        //    try
        //    {
        //        _lock.Enter(ref lockTaken);
        //        if (Volatile.Read(ref _source) is { } source)
        //        {
        //            source.TrySetException(exception);
        //        }
        //        else
        //        {
        //            _exception = exception;
        //        }
        //    }
        //    finally
        //    {
        //        if (lockTaken)
        //            _lock.Exit();
        //    }
        //}

        //public void SetResult(T result)
        //{
        //    var lockTaken = false;
        //    try
        //    {
        //        _lock.Enter(ref lockTaken);
        //        if (Volatile.Read(ref _source) is { } source)
        //        {
        //            source.TrySetResult(result);
        //        }
        //        else
        //        {
        //            _result = result;
        //            _hasResult = true;
        //        }
        //    }
        //    finally
        //    {
        //        if (lockTaken)
        //            _lock.Exit();
        //    }
        //}

        //public void SetStateMachine(IAsyncStateMachine stateMachine) { }

        //public void Start<TStateMachine>(ref TStateMachine stateMachine)
        //    where TStateMachine : IAsyncStateMachine => stateMachine.MoveNext();

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            Action move = stateMachine.MoveNext;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                move();
            });
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            // nothing to do
        }


        #endregion
    }






    internal class AsyncMethodBuilderExample
    {
        public async CustomAwaitable RunMe()
        {
            await Task.Yield();
        }  
    }
}
