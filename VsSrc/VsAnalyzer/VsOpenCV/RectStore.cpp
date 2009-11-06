#include "stdafx.h"
#include "RectStore.h"
#include "cv.h"

CvRectStore::CvRectStore(){
	id=-1;
	rect=cvRect(0,0,0,0);
}
CvRectStore::~CvRectStore(){
}
