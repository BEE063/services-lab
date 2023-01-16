Vagrant.configure("2") do | config |
    config.vm.define "service" do |service|
        service.vm.box = "Ubuntu-Vagrant"
        service.vm.hostname = "servicelab"
        service.vm.network "private_network", ip: "192.168.99.100"
	service.vm.network "forwarded_port", guest: 80, host: 8000
        service.vm.network "forwarded_port", guest: 5050, host: 5050        
        service.vm.provision "shell", path: "docker-setup.sh"
        service.vm.provider "virtualbox" do |vb|
            vb.customize ["modifyvm", :id, "--memory", "2048"]
	service.vm.provision :docker
        service.vm.provision :docker_compose, yml: "/vagrant/docker-compose.yml", run: "always"
        end
    end    
end
