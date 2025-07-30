docker build -t linuxfilesystem1:1.0.0 -f ./LinuxFileSystemDemo/Dockerfile .

docker run -v C:/mnt/WebVotes:/app/mnt/WebVotes linuxfilesystem1:1.0.0