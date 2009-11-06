class MediaReferenceSet {
	private var referenceSet:Array = new Array();

	/** Constructor for the BandwidthCheck **/
	function BandwidthCheck() {
	};

	public function put(ref:MediaReference) {
		referenceSet.push(ref);
	}
	
	public function findFit(kbps:Number) {
		var closestFit:MediaReference;
		for (var i = 0; i < referenceSet.length; i++) {
			var ref = referenceSet[i];
			
			if (Number(ref.getBitrate()) <= kbps) { // this one fits
				if (closestFit == undefined || ref.getBitrate() > closestFit.getBitrate()) {
					closestFit = ref;
				}
			}
		}
		
		return closestFit != undefined ? closestFit : getMinimum();
	}
	
	public function getMinimum() {
		var lowest:MediaReference;
		for (var i = 0; i < referenceSet.length; i++) {
			var ref = referenceSet[i];
			
			if (lowest == undefined || ref.getBitrate() < lowest.getBitrate()) {
				lowest = ref;
			}
		}
		return lowest;
	}
}