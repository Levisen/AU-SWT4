void * writer(void * sharedPtr)
{
	//Cast paramter to Vector pointer
	Vector * sharedVectorPtr = static_cast<Vector*>(sharedPtr);

	//Create variable to set how many times to compare
	int maxNo = 10;

	//Get thread ID
	pthread_t threadID = pthread_self();

	for (int i = 0; i < maxNo; ++i)
	{
	 //Check Vector with thread ID
	 if(sharedVectorPtr->setAndTest(threadID) == false)
		 std::cout << "Error in thread number: " << threadID << std::endl;

	 //Wait 1 second
	 sleep(1);
	}

	//Return nullptr
	return nullptr;
}