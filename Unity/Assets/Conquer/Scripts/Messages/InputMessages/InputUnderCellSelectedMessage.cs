using Assets.Conquer.Scripts.Models;
using UnityEngine;

namespace Conquer.Messages.InputMessages
{
	public struct InputUnderCellSelectedMessage
	{
		public RaycastHit Hit;
		public CellData Cell;
	}
}
