using strange.extensions.command.impl;

public class TowerShootCommand : Command {

	[Inject]
    public TowerView tower { get; set; }

	public override void Execute(){
		tower.Fire ();

	}
}
