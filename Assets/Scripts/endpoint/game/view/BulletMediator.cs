using strange.extensions.mediation.impl;

namespace endpoint.game
{
	public class BulletMediator : Mediator
	{

		[Inject]
		public BulletView View { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();
        }
	}
}

