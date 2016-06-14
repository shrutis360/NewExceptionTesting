// Test Standard
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace NewExcepTesting
{
	class MainClass
	{
		public static void SomeMethod ()
		{
			haha ().Wait ();
		}

		static async Task haha ()
		{
			await Task.Delay (1000).ConfigureAwait (false);
			await papa ();
		}

		static async Task papa ()
		{
			await Task.Delay (1000).ConfigureAwait (false);
			//new object[0].Select<
			throw new FieldAccessException ("aaa");
		}

		public static void Main (string [] args)
		{
			//TestDivbyZero ();
			//DivideByTwo (3);
			var exceptions = new ConcurrentQueue<Exception> ();
			//throw new Exception ();//Uncomment for single exception
			Parallel.For (0L, 500L, i => {
				try {
					if (i % 100 == 0) {
						if (i % 50 == 0) {
							try {
								typeof (MainClass).GetMethod ("SomeMethod").Invoke (null, null);
							} catch (Exception ex2) {
								throw new NotImplementedException ("bbb", ex2);
							}
						}
						throw new TimeoutException ("i = " + i.ToString ());
					}
				} catch (Exception e) {
					exceptions.Enqueue (e);
				}
			});

			if (exceptions.Count > 0) {
				throw new AggregateException (exceptions);
				//throw new NotImplementedException ("aaa");

			}
		}

		static int TestDivbyZero ()
		{
			int a = 12;
			return a / 0;

		}

		static int DivideByTwo (int num)
		{
			// If num is an odd number, throw an ArgumentException.
			if ((num & 1) == 1)
				throw new ArgumentException (String.Format ("{0} is not an even number", num),
							  "num");

			// num is even, return half of its value.
			return num / 2;
		}
	}
}
