using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircuitBreakDyamicLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakDyamicLib.Tests
{
    [TestClass()]
    public class CircuitBreakerInterceptorTests
    {
        [TestMethod()]
        public void InterceptTest()
        {
            //建立proxy元件
            var generator = new Castle.DynamicProxy.ProxyGenerator();

            var timeout = TimeSpan.FromMinutes(1);

            var breaker = new CircuitBreaker(timeout);
            //產生interceptor(攔截器)
            var interceptor = new CircuitBreakerInterceptor(breaker);

            var wcfRepository = new WcfProductRepository();
            //產生裝飾後的物件
            IRepository repository = generator.CreateInterfaceProxyWithTarget<IRepository>(wcfRepository,interceptor);
            //因wcfRepository已經被裝飾成repository，所以後續使用repository這個變數才會有interceptor的效果
            repository.Count();
        }

        /// <summary>
        /// 使用KingAOP實作後編譯織入的測試
        /// </summary>
        [TestMethod]
        public void CountInterceptorKingAOPTest()
        {
            //必需使用dynamic
            dynamic wcfRepository = new WcfProductRepository();
            wcfRepository.Count();
        }
    }
}