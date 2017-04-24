using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=33"), TaskDescription("The random probability task will return success when the random probability is above the succeed probability. It will otherwise return failure.")]
	public class RandomProbability : Conditional
	{
		[Tooltip("The chance that the task will return success")]
		public SharedFloat successProbability = 0.5f;

		[Tooltip("Seed the random number generator to make things easier to debug")]
		public SharedInt seed;

		[Tooltip("Do we want to use the seed?")]
		public SharedBool useSeed;

		private Random random;

		public override void OnAwake()
		{
			if (this.useSeed.Value)
			{
				this.random = new Random(this.seed.Value);
			}
			else
			{
				this.random = new Random();
			}
		}

		public override TaskStatus OnUpdate()
		{
			float num = (float)this.random.NextDouble();
			if (num < this.successProbability.Value)
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}

		public override void OnReset()
		{
			this.successProbability = 0.5f;
			this.seed = 0;
			this.useSeed = false;
		}
	}
}
