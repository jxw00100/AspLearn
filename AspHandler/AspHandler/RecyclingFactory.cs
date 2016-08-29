using System;
using System.Web;
using System.Collections.Concurrent;

namespace AspHandler
{
    public class RecyclingFactory : IHttpHandlerFactory
    {
        private BlockingCollection<RecyclingHandler> _pool = new BlockingCollection<RecyclingHandler>();
        private int _handler_count = 0;
        private int _handler_limit = 100;
        private int _totalRequests = 0;

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            _totalRequests++;

            RecyclingHandler handler;
            if (!_pool.TryTake(out handler))
            {
                if (_handler_count < _handler_limit)
                {
                    _handler_count++;
                    handler = new RecyclingHandler(this, _handler_count);
                    _pool.Add(handler);
                }
                else
                {
                    handler = _pool.Take();
                }
            }

            handler.RequestCount++;
            return handler;
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
            if (handler.IsReusable)
            {
                _pool.Add((RecyclingHandler)handler);
            }
        }

        public int TotalRequests
        {
            get { return _totalRequests; }
        }
    }

    public class RecyclingHandler: IHttpHandler{
        private int _handlerId;
        private RecyclingFactory _factory;

        public RecyclingHandler(RecyclingFactory factory, int id){
            _factory = factory;
            _handlerId = id;
        }

        public int RequestCount{get;set;}

        public void ProcessRequest(HttpContext context){
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format(
                "Total requests: {0}, HandlerId: {1}, Handler Requests {2}",
                _factory.TotalRequests, _handlerId, RequestCount));
        }

        public bool IsReusable{
            get {return RequestCount< 4;}
        }
    }
}
