using NUnit.Framework;

namespace weapon
{
	namespace stat
	{
		public class Test_stat
		{
			[Test]
			public void should_have_a_default()
			{
				var ammo = Gun_stat.CreateInstance<Gun_stat>();
				var d = ammo.find_default<Gun_stat>();
				Assert.IsNotNull( d );
			}
		}
	}
}
