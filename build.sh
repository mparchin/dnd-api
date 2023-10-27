#!/bin/sh
IMAGE="mparchin/dnd-api"
ADDRESS="dnd-api"
if [ "$1" = "production" ]
  then
    BRANCH=$1
  else
    BRANCH="development"
fi
SERVER="91.107.242.150"
ssh $SERVER "cd $ADDRESS && \
git switch $BRANCH && \
git pull && \
docker buildx build -t $IMAGE:$BRANCH --push ."