package io.jenkins.plugins.dockerHubLink;

import hudson.model.Action;
import hudson.model.Run;
import jenkins.model.RunAction2;

public class DockerHubLinkAction implements RunAction2 { 

    private transient Run run;

    @Override
    public void onAttached(Run<?, ?> run) {
        this.run = run; 
    }

    @Override
    public void onLoad(Run<?, ?> run) {
        this.run = run; 
    }

    public Run getRun() { 
        return run;
    }
    
    @Override
    public String getIconFileName() {
        return "document.png";
    }

    @Override
    public String getDisplayName() {
        return "Docker Hub Link";
    }

    @Override
    public String getUrlName() {
        return "dockerhub";
    }

    private String repositoryOwner;

    public DockerHubLinkAction(String repositoryOwner) {      
        this.repositoryOwner = repositoryOwner;
    }

    public String getImageTag() {
        return this.repositoryOwner + "/" + this.run.getParent().getName();
    }

    public String getImageUrl() {
        return  "https://hub.docker.com/r/" + this.repositoryOwner + "/" + this.run.getParent().getDisplayName() + "/tags";
    }
}