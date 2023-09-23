package io.jenkins.plugins.dockerHubLink;

import hudson.Launcher;
import hudson.Extension;
import hudson.FilePath;
import hudson.util.FormValidation;
import hudson.model.AbstractProject;
import hudson.model.Run;
import hudson.model.TaskListener;
import hudson.model.AbstractBuild;
import hudson.model.BuildListener;
import hudson.tasks.BuildStepDescriptor;
import hudson.tasks.Recorder;
import hudson.tasks.Publisher;
import org.kohsuke.stapler.DataBoundConstructor;
import org.kohsuke.stapler.QueryParameter;

import javax.servlet.ServletException;
import java.io.IOException;
import jenkins.tasks.SimpleBuildStep;
import org.jenkinsci.Symbol;
import org.kohsuke.stapler.DataBoundSetter;

public class DockerHubLinkRecorder extends Recorder {

    private final String repositoryOwner;
    private boolean useBuildNumber;

    @DataBoundConstructor
    public DockerHubLinkRecorder(String repositoryOwner) {
        this.repositoryOwner = repositoryOwner;
    }

    public String getRepositoryOwner() {
        return repositoryOwner;
    }

    public boolean isUseBuildNumber() {
        return useBuildNumber;
    }

    @DataBoundSetter
    public void setUseBuildNumber(boolean useBuildNumber) {
        this.useBuildNumber = useBuildNumber;
    }

    @Override
    public boolean perform(AbstractBuild build, Launcher launcher, BuildListener listener) throws IOException {
         if (this.repositoryOwner.length() < 4) {
            throw new IOException("Invalid owner name!");
         }
         build.addAction(new DockerHubLinkAction(repositoryOwner));
         return true;
    }

    @Symbol("dockerHub")
    @Extension
    public static final class DescriptorImpl extends BuildStepDescriptor<Publisher> {

        public FormValidation doCheckRepositoryOwner(@QueryParameter String value)
                throws IOException, ServletException {
            if (value.length() < 4)
                return FormValidation.error("Repository owner name is too short");
            return FormValidation.ok();
        }

        @Override
        public boolean isApplicable(Class<? extends AbstractProject> aClass) {
            return true;
        }

        @Override
        public String getDisplayName() {
            return "Add Docker Hub link";
        }
    }
}
