using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnityEngine;
using App.Core.Modules.AppTask;
using OpenGameFramework;

namespace App
{
    public partial class App : MonoBehaviour
    {
        private List<int> _test;
        // Start is called before the first frame update
        async void Start()
        {
            await new AppTask(test)
                .Then(LogMessageWithDelay)
                .Then(lala)
                .Run();

            
            //await task.Run();
        }

        public static void Te()
        {
            
        }

        private IEnumerator test()
        {
            _test.Add(2);
            Debug.Log("test");
            yield return new WaitForEndOfFrame();
        }

        private void lala()
        {
            Debug.Log("Lala");
        }

        private async Task LogMessageWithDelay()
        {
            await Task.Delay(4000);
            Debug.Log("Message after 4 seconds");
        }
    }
}